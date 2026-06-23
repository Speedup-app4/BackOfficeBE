using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BackOffice.Entity.System;
using BackOffice.Interfaces.Base;
using BackOffice.Interfaces.Modules.System;

namespace BackOffice.Services.Modules.System
{
    public class SalesTypeService(IUnitOfWork _uow)
    {
        public async Task<IEnumerable<SalesType>> GetAll(Guid clientId)
        {
            return await _uow.SalesType.GetAllAsync(true, clientId);
        }

        public async Task<SalesType> Create(Guid clientId, SalesType salesType)
        {
            try
            {
                _uow.BeginTransaction();
                var SALETYPEINDEX = await _uow.AutoInc.GetNextSequenceAsync(
                    AutoIncType.GETNEXT_SALETYPE,
                    clientId
                );
                salesType.SALETYPEINDEX = SALETYPEINDEX;
                salesType.ClientId = clientId;

                var createdSalesType = await _uow.SalesType.AddAsync(salesType);
                _uow.Commit();
                return createdSalesType;
            }
            catch
            {
                _uow.Rollback();
                throw;
            }
        }

        public async Task<SalesType> Update(Guid clientId, SalesTypeUpdate salesType)
        {
            try
            {
                _uow.BeginTransaction();
                var updatedSalesType = await _uow.SalesType.UpdatePartialAsync(
                    salesType,
                    salesType.SALETYPEINDEX,
                    clientId
                );
                _uow.Commit();
                return updatedSalesType;
            }
            catch
            {
                _uow.Rollback();
                throw;
            }
        }
    }
}
