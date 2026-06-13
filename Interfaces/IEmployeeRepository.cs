using BackOffice.Entity.Employees;
using BackOffice.Interfaces.Base;

namespace BackOffice.Interfaces
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        Task<Employee?> GetBySwipeAsync(Guid clientId, string swipe);
    }
}
