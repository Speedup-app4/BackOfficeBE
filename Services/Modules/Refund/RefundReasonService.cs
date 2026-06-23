using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BackOffice.Entity.Refund;
using BackOffice.Interfaces.Base;
using BackOffice.Interfaces.Modules.System;

namespace BackOffice.Services.Modules.Refund
{
    public class RefundReasonService(IUnitOfWork _uow)
    {
        public async Task<IEnumerable<RefundReason>> GetAll(Guid clientId)
        {
            return await _uow.RefundReason.GetAllAsync(true, clientId);
        }

        public async Task<RefundReason> Create(Guid clientId, RefundReason refundReason)
        {
            try
            {
                _uow.BeginTransaction();
                var REFNUM = await _uow.AutoInc.GetNextSequenceAsync(
                    AutoIncType.GETNEXT_REFUNDREASON,
                    clientId
                );
                refundReason.REFNUM = REFNUM;
                refundReason.ClientId = clientId;

                var createdRefundReason = await _uow.RefundReason.AddAsync(refundReason);
                _uow.Commit();
                return createdRefundReason;
            }
            catch
            {
                _uow.Rollback();
                throw;
            }
        }

        public async Task<RefundReason> Update(Guid clientId, RefundReasonUpdate refundReason)
        {
            try
            {
                _uow.BeginTransaction();
                var updatedRefundReason = await _uow.RefundReason.UpdatePartialAsync(
                    refundReason,
                    refundReason.REFNUM,
                    clientId
                );
                _uow.Commit();
                return updatedRefundReason;
            }
            catch
            {
                _uow.Rollback();
                throw;
            }
        }
    }
}
