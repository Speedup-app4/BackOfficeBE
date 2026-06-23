using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BackOffice.Entity.Employees;
using BackOffice.Interfaces.Base;

namespace BackOffice.Interfaces.Modules.Employees
{
    public interface IPayRollRepository : IGenericRepository<PayRoll>
    {
        Task<IEnumerable<PayRoll>> GetByEmpNum(Guid clientId, int empNum);
    }
}
