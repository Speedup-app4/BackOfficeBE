using BackOffice.Entity.Employees;
using BackOffice.Interfaces;
using BackOffice.Interfaces.Base;
using BackOffice.Repositories.Base;
using Dapper;

namespace BackOffice.Repositories
{
    public class EmployeeRepository(IUnitOfWork _uow)
        : GenericRepository<Employee>(_uow),
            IEmployeeRepository
    {
        public async Task<Employee?> GetBySwipeAsync(Guid clientId, string swipe)
        {
            var sql = "SELECT * FROM Employee WHERE SWIPE = @Swipe AND ClientId = @ClientId";
            var parameters = new { Swipe = swipe, ClientId = clientId };
            return await _uow.Connection.QueryFirstOrDefaultAsync<Employee>(
                sql,
                parameters,
                _uow.Transaction
            );
        }
    }
}
