using System;
using System.Threading.Tasks;
using BackOffice.Interfaces.Base;
using BackOffice.Interfaces.Modules.System;
using BackOffice.Repositories.Base;
using Dapper;

namespace BackOffice.Repositories.Modules.System
{
    public class AutoIncRepository(IUnitOfWork _uow)
        : GenericRepository<object>(_uow),
            IAutoIncRepository
    {
        public async Task<int> GetNextSequenceAsync(
            AutoIncType incType,
            Guid clientId,
            Guid? storeId,
            int incrementBy = 1
        )
        {
            var sql =
                @"
                UPDATE ""AUTOINCINDEX"" 
                SET ""NEXTNUM"" = ""NEXTNUM"" + @incrementBy 
                WHERE ""ClientId"" = @clientId AND ""INCNAME"" = @incName";

            if (storeId.HasValue)
            {
                sql += " AND \"StoreId\" = @storeId";
            }

            sql += " RETURNING \"NEXTNUM\";";

            return await _uow.Connection.QuerySingleAsync<int>(
                sql,
                new
                {
                    clientId,
                    storeId,
                    incName = incType.ToString(),
                    incrementBy,
                },
                _uow.Transaction
            );
        }
    }
}
