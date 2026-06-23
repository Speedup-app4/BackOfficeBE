using System;
using System.Threading.Tasks;
using BackOffice.Entity.Employees;
using BackOffice.Interfaces.Base;
using BackOffice.Interfaces.Modules.Employees;
using BackOffice.Repositories.Base;
using Dapper;

namespace BackOffice.Repositories.Modules.Employees
{
    public class EmployeeRepository(IUnitOfWork _uow)
        : GenericRepository<Employee>(_uow),
            IEmployeeRepository
    {
        public async Task<Employee?> GetBySwipeAsync(Guid clientId, string swipe)
        {
            var sql =
                @"SELECT * FROM ""employee"" WHERE ""SWIPE"" = @Swipe AND ""ClientId"" = @ClientId";
            var parameters = new { Swipe = swipe, ClientId = clientId };
            return await _uow.Connection.QueryFirstOrDefaultAsync<Employee>(
                sql,
                parameters,
                _uow.Transaction
            );
        }
    }
}
