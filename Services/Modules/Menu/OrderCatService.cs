using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BackOffice.Entity.Menu;
using BackOffice.Interfaces.Base;
using BackOffice.Interfaces.Modules.System;

namespace BackOffice.Services.Modules.Menu
{
    public class OrderCatService(IUnitOfWork _uow)
    {
        public async Task<IEnumerable<OrderCat>> GetAll(Guid clientId)
        {
            return await _uow.OrderCat.GetAllAsync(true, clientId);
        }

        public async Task<OrderCat> Create(Guid clientId, OrderCat orderCat)
        {
            try
            {
                _uow.BeginTransaction();
                var ORDERCAT = await _uow.AutoInc.GetNextSequenceAsync(
                    AutoIncType.GETNEXT_ORDERCAT,
                    clientId
                );
                orderCat.ORDERCAT = ORDERCAT;
                orderCat.ClientId = clientId;

                var createdOrderCat = await _uow.OrderCat.AddAsync(orderCat);
                _uow.Commit();
                return createdOrderCat;
            }
            catch
            {
                _uow.Rollback();
                throw;
            }
        }

        public async Task<OrderCat> Update(Guid clientId, OrderCatUpdate orderCat)
        {
            try
            {
                _uow.BeginTransaction();
                var updatedOrderCat = await _uow.OrderCat.UpdatePartialAsync(
                    orderCat,
                    orderCat.ORDERCAT,
                    clientId
                );
                _uow.Commit();
                return updatedOrderCat;
            }
            catch
            {
                _uow.Rollback();
                throw;
            }
        }
    }
}
