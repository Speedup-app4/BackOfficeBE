using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BackOffice.Entity.Payment;
using BackOffice.Interfaces.Base;
using BackOffice.Interfaces.Modules.System;

namespace BackOffice.Services.Modules.Payment
{
    public class MethodPayService(IUnitOfWork _uow)
    {
        public async Task<IEnumerable<MethodPay>> GetAll(Guid clientId)
        {
            return await _uow.MethodPay.GetAllAsync(true, clientId);
        }

        public async Task<MethodPay> Create(Guid clientId, MethodPay methodPay)
        {
            try
            {
                _uow.BeginTransaction();
                var METHODNUM = await _uow.AutoInc.GetNextSequenceAsync(
                    AutoIncType.GETNEXT_METHODPAYMENT,
                    clientId
                );
                methodPay.METHODNUM = METHODNUM;
                methodPay.ClientId = clientId;

                var createdMethodPay = await _uow.MethodPay.AddAsync(methodPay);
                _uow.Commit();
                return createdMethodPay;
            }
            catch
            {
                _uow.Rollback();
                throw;
            }
        }

        public async Task<MethodPay> Update(Guid clientId, MethodPayUpdate methodPay)
        {
            try
            {
                _uow.BeginTransaction();
                var updatedMethodPay = await _uow.MethodPay.UpdatePartialAsync(
                    methodPay,
                    methodPay.METHODNUM,
                    clientId
                );
                _uow.Commit();
                return updatedMethodPay;
            }
            catch
            {
                _uow.Rollback();
                throw;
            }
        }
    }
}
