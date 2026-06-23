using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackOffice.Entity.Coupon;
using BackOffice.Interfaces.Base;
using BackOffice.Interfaces.Modules.System;

namespace BackOffice.Services.Modules.Coupon
{
    public class PromoService(IUnitOfWork _uow)
    {
        public async Task<IEnumerable<Promo>> Get(Guid clientId, int? promoNum = null)
        {
            var promoList = new List<Promo>();
            var promoReportCatList = new List<PromoReportCat>();

            if (promoNum.HasValue)
            {
                var promo =
                    await _uow.Promo.GetByIdAsync(promoNum.Value, true, clientId)
                    ?? throw new Exception("Không tìm thấy Promo");

                promoList.Add(promo);

                var details = await _uow.PromoReportCat.GetByPromoNum(clientId, promoNum.Value);

                if (details != null)
                    promoReportCatList.AddRange(details);
            }
            else
            {
                var promos = await _uow.Promo.GetAllAsync(true, clientId);

                promoList.AddRange(promos);

                var details = await _uow.PromoReportCat.GetAllAsync(true, clientId);
                if (details != null)
                    promoReportCatList.AddRange(details);
            }

            var joinData = promoList.Select(p =>
            {
                p.PromoReportCats = [.. promoReportCatList.Where(x => x.PROMONUM == p.PROMONUM)];
                return p;
            });

            return joinData;
        }

        public async Task<Promo> Create(Guid clientId, Promo promo)
        {
            try
            {
                _uow.BeginTransaction();
                var newPromoNum = await _uow.AutoInc.GetNextSequenceAsync(
                    AutoIncType.GETNEXT_PROMO,
                    clientId
                );

                promo.PROMONUM = newPromoNum;
                promo.ClientId = clientId;

                var reportCatsToInsert = new List<PromoReportCat>();

                if (promo.PromoReportCats != null && promo.PromoReportCats.Any())
                {
                    var nextSequence = await _uow.AutoInc.GetNextSequenceAsync(
                        AutoIncType.GETNEXT_PromoReport,
                        clientId,
                        null,
                        promo.PromoReportCats.Count
                    );

                    int startSequence = nextSequence - promo.PromoReportCats.Count + 1;

                    foreach (var rptCat in promo.PromoReportCats)
                    {
                        rptCat.UNIQUEID = startSequence++;
                        rptCat.ClientId = clientId;
                        rptCat.PROMONUM = newPromoNum;
                        reportCatsToInsert.Add(rptCat);
                    }
                }

                var createdPromo = await _uow.Promo.AddAsync(promo);

                if (reportCatsToInsert.Count > 0)
                {
                    await _uow.PromoReportCat.AddRangeAsync(reportCatsToInsert);
                    createdPromo.PromoReportCats = reportCatsToInsert;
                }
                _uow.Commit();
                return createdPromo;
            }
            catch
            {
                _uow.Rollback();
                throw;
            }
        }

        public async Task<Promo> Update(Guid clientId, PromoUpdate updateDto)
        {
            try
            {
                _uow.BeginTransaction();

                var updatedPromo = await _uow.Promo.UpdatePartialAsync(
                    updateDto,
                    updateDto.PROMONUM,
                    clientId
                );

                if (updateDto.PromoReportCats != null)
                {
                    var oldReportCats = await _uow.PromoReportCat.GetByPromoNum(
                        clientId,
                        updateDto.PROMONUM
                    );

                    var catsToInsert = new List<PromoReportCat>();
                    var catsToUpdate = new List<PromoReportCat>();
                    var catsToDelete = new List<PromoReportCat>();

                    foreach (var oldCat in oldReportCats)
                    {
                        var incomingCat = updateDto.PromoReportCats.FirstOrDefault(c =>
                            c.UNIQUEID == oldCat.UNIQUEID
                        );

                        if (incomingCat != null)
                            catsToUpdate.Add(incomingCat);
                        else
                            catsToDelete.Add(oldCat);
                    }

                    var newCats = updateDto.PromoReportCats.Where(c => c.UNIQUEID == 0).ToList();

                    if (newCats.Count > 0)
                    {
                        var currentNextNumFromDb = await _uow.AutoInc.GetNextSequenceAsync(
                            AutoIncType.GETNEXT_PromoReport,
                            clientId,
                            null,
                            newCats.Count
                        );

                        int startSequence = currentNextNumFromDb - newCats.Count + 1;

                        foreach (var newCat in newCats)
                        {
                            var catEntity = new PromoReportCat
                            {
                                ClientId = clientId,
                                UNIQUEID = startSequence++,
                                PROMONUM = updateDto.PROMONUM,
                                REPORTNO = newCat.REPORTNO,
                                ProdNum = newCat.ProdNum,
                                RequiredItem = newCat.RequiredItem,
                            };
                            catsToInsert.Add(catEntity);
                        }
                    }

                    if (catsToInsert.Count > 0)
                        await _uow.PromoReportCat.AddRangeAsync(catsToInsert);

                    if (catsToUpdate.Count > 0)
                    {
                        foreach (var upd in catsToUpdate)
                        {
                            await _uow.PromoReportCat.UpdatePartialAsync(
                                upd,
                                upd.UNIQUEID,
                                clientId
                            );
                        }
                    }

                    if (catsToDelete.Count > 0)
                    {
                        foreach (var del in catsToDelete)
                        {
                            await _uow.PromoReportCat.UpdatePartialAsync(
                                new { IsActive = (short)0 },
                                del.UNIQUEID,
                                clientId
                            );
                        }
                    }

                    updatedPromo.PromoReportCats = [.. catsToUpdate, .. catsToInsert];
                }

                _uow.Commit();

                return updatedPromo;
            }
            catch
            {
                _uow.Rollback();
                throw;
            }
        }
    }
}
