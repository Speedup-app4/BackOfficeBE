using System;
using System.Threading.Tasks;
using BackOffice.Entity.Employees;
using BackOffice.Interfaces.Base;

namespace BackOffice.Interfaces.Modules.Employees
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        Task<Employee?> GetBySwipeAsync(Guid clientId, string swipe);
    }
}
