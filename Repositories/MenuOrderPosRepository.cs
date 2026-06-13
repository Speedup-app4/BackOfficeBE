using BackOffice.Entity.Menu;
using BackOffice.Interfaces;
using BackOffice.Interfaces.Base;
using BackOffice.Repositories.Base;
using Dapper;

namespace BackOffice.Repositories
{
    public class MenuOrderPosRepository(IUnitOfWork _uow)
        : GenericRepository<MenuOrderPos>(_uow),
            IMenuOrderPosRepository
    {
        public Task<IEnumerable<MenuOrderPos>> GetByMenuIndex(int menuIndex, Guid clientId)
        {
            var sql =
                @"
                SELECT * FROM ""MENUORDERPOS"" 
                WHERE ""MENUINDEX"" = @MenuIndex 
                AND ""ClientId"" = @ClientId 
                ORDER BY ""ORDERPOS""";
            var parameters = new { MenuIndex = menuIndex, ClientId = clientId };
            return _uow.Connection.QueryAsync<MenuOrderPos>(sql, parameters);
        }
    }
}
