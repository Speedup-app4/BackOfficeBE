using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BackOffice.Entity.Employees;
using BackOffice.Interfaces.Base;

namespace BackOffice.Services.Modules.Employees
{
    public class PayRollService(IUnitOfWork _uow)
    {
        public async Task<IEnumerable<PayRoll>> GetAll(Guid clientId)
        {
            return await _uow.PayRoll.GetAllAsync(true, clientId);
        }
    }
}
