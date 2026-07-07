using System;
using System.Threading.Tasks;
using BackOffice.Entity.CaaS;
using BackOffice.Entity.Employees;
using BackOffice.Interfaces.Base;

namespace BackOffice.Services.Modules.CaaS
{
    public class ClientService(IUnitOfWork _uow)
    {
        public async Task<Client> Get(Guid clientId)
        {
            return await _uow.Client.GetByIdAsync(clientId, null, true)
                ?? throw new Exception($"Client with ID {clientId} not found.");
        }

        public async Task<Employee> Login(Guid clientId, string swipe)
        {
            var employee =
                await _uow.Employee.GetBySwipeAsync(clientId, swipe)
                ?? throw new Exception($"Employee with swipe {swipe} not found.");
            if (employee.ISACTIVE == 0)
                throw new Exception($"Employee with swipe {swipe} is inactive.");
            return employee;
        }
    }
}
