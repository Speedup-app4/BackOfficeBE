using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BackOffice.Entity.Menu;
using BackOffice.Interfaces.Base;
using BackOffice.Interfaces.Modules.Menu;
using BackOffice.Repositories.Base;
using Dapper;

namespace BackOffice.Repositories.Modules.Menu
{
    public class MenuProdPosRepository(IUnitOfWork _uow)
        : GenericRepository<MenuProdPos>(_uow),
            IMenuProdPosRepository
    {
        public Task<IEnumerable<MenuProdPos>> GetByOrderCat(int orderCat, Guid clientId)
        {
            var sql =
                @"
                SELECT * FROM ""MENUPRODPOS""
                WHERE ""ORDERCAT"" = @OrderCat
                AND ""ClientId"" = @ClientId
                ORDER BY ""PRODPOS""";
            var parameters = new { OrderCat = orderCat, ClientId = clientId };
            return _uow.Connection.QueryAsync<MenuProdPos>(sql, parameters);
        }
    }
}
