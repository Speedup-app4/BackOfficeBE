using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackOffice.Entity.Coupon;
using BackOffice.Interfaces.Base;
using BackOffice.Interfaces.Modules.System;

namespace BackOffice.Services.Modules.Coupon
{
    public class PromoGrpService(IUnitOfWork _uow)
    {
        public async Task<IEnumerable<PromoGrp>> Get(Guid clientId, int? promoGrpId = null)
        {
            var promoGrpList = new List<PromoGrp>();
            var promoGrpDetailList = new List<PromoGrpDetail>();

            if (promoGrpId.HasValue)
            {
                var promoGrp =
                    await _uow.PromoGrp.GetByIdAsync(promoGrpId.Value, true, clientId)
                    ?? throw new Exception("Không tìm thấy Promo Group");

                promoGrpList.Add(promoGrp);

                var details = await _uow.PromoGrpDetail.GetByGrpId(clientId, promoGrpId.Value);
                if (details != null)
                    promoGrpDetailList.AddRange(details);
            }
            else
            {
                var grps = await _uow.PromoGrp.GetAllAsync(true, clientId);
                promoGrpList.AddRange(grps);

                var details = await _uow.PromoGrpDetail.GetAllAsync(true, clientId);
                if (details != null)
                    promoGrpDetailList.AddRange(details);
            }

            var joinData = promoGrpList.Select(g =>
            {
                g.PromoGrpDetails =
                [
                    .. promoGrpDetailList.Where(d => d.PromoGrpID == g.PromoGrpID),
                ];
                return g;
            });

            return joinData;
        }

        public async Task<PromoGrp> Create(Guid clientId, PromoGrp promoGrp)
        {
            try
            {
                _uow.BeginTransaction();

                var newGrpId = await _uow.AutoInc.GetNextSequenceAsync(
                    AutoIncType.GetNext_PromoGrpID,
                    clientId
                );

                promoGrp.PromoGrpID = newGrpId;
                promoGrp.ClientId = clientId;

                var detailsToInsert = new List<PromoGrpDetail>();

                if (promoGrp.PromoGrpDetails != null && promoGrp.PromoGrpDetails.Any())
                {
                    var nextSequence = await _uow.AutoInc.GetNextSequenceAsync(
                        AutoIncType.GetNext_PromoGrpDetailID,
                        clientId,
                        null,
                        promoGrp.PromoGrpDetails.Count
                    );

                    int startSequence = nextSequence - promoGrp.PromoGrpDetails.Count + 1;

                    foreach (var detail in promoGrp.PromoGrpDetails)
                    {
                        detail.PromoGrpDetailID = startSequence++;
                        detail.PromoGrpID = newGrpId;
                        detail.ClientId = clientId;
                        detailsToInsert.Add(detail);
                    }
                }

                var createdGrp = await _uow.PromoGrp.AddAsync(promoGrp);

                if (detailsToInsert.Count > 0)
                {
                    await _uow.PromoGrpDetail.AddRangeAsync(detailsToInsert);
                    createdGrp.PromoGrpDetails = detailsToInsert;
                }

                _uow.Commit();
                return createdGrp;
            }
            catch
            {
                _uow.Rollback();
                throw;
            }
        }

        public async Task<PromoGrp> Update(Guid clientId, PromoGrpUpdate updateDto)
        {
            try
            {
                _uow.BeginTransaction();

                updateDto.UpdateStatus = 1;
                var updatedGrp = await _uow.PromoGrp.UpdatePartialAsync(
                    updateDto,
                    updateDto.PromoGrpID,
                    clientId
                );

                if (updateDto.PromoGrpDetails != null)
                {
                    var oldDetails = await _uow.PromoGrpDetail.GetByGrpId(
                        clientId,
                        updateDto.PromoGrpID
                    );

                    var detailsToInsert = new List<PromoGrpDetail>();
                    var detailsToUpdate = new List<PromoGrpDetail>();
                    var detailsToDelete = new List<PromoGrpDetail>();

                    foreach (var oldDetail in oldDetails)
                    {
                        var incomingDetail = updateDto.PromoGrpDetails.FirstOrDefault(d =>
                            d.PromoGrpDetailID == oldDetail.PromoGrpDetailID
                        );

                        if (incomingDetail != null)
                        {
                            incomingDetail.UpdateStatus = 1;
                            detailsToUpdate.Add(incomingDetail);
                        }
                        else
                            detailsToDelete.Add(oldDetail);
                    }

                    var newDetails = updateDto
                        .PromoGrpDetails.Where(d => d.PromoGrpDetailID == 0)
                        .ToList();

                    if (newDetails.Count > 0)
                    {
                        var currentNextNumFromDb = await _uow.AutoInc.GetNextSequenceAsync(
                            AutoIncType.GetNext_PromoGrpDetailID,
                            clientId,
                            null,
                            newDetails.Count
                        );

                        int startSequence = currentNextNumFromDb - newDetails.Count + 1;

                        foreach (var newDetail in newDetails)
                        {
                            var detailEntity = new PromoGrpDetail
                            {
                                ClientId = clientId,
                                PromoGrpDetailID = startSequence++,
                                PromoGrpID = updateDto.PromoGrpID,
                                PromoNum = newDetail.PromoNum,
                                Sequence = newDetail.Sequence,
                            };
                            detailsToInsert.Add(detailEntity);
                        }
                    }

                    if (detailsToInsert.Count > 0)
                        await _uow.PromoGrpDetail.AddRangeAsync(detailsToInsert);

                    if (detailsToUpdate.Count > 0)
                    {
                        foreach (var upd in detailsToUpdate)
                        {
                            await _uow.PromoGrpDetail.UpdatePartialAsync(
                                upd,
                                upd.PromoGrpDetailID,
                                clientId
                            );
                        }
                    }

                    if (detailsToDelete.Count > 0)
                    {
                        foreach (var del in detailsToDelete)
                        {
                            await _uow.PromoGrpDetail.UpdatePartialAsync(
                                new { IsActive = (short)0, UpdateStatus = (short)1 },
                                del.PromoGrpDetailID,
                                clientId
                            );
                        }
                    }

                    updatedGrp.PromoGrpDetails = [.. detailsToUpdate, .. detailsToInsert];
                }

                _uow.Commit();

                return updatedGrp;
            }
            catch
            {
                _uow.Rollback();
                throw;
            }
        }
    }
}
