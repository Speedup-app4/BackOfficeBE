using System;
using System.Threading.Tasks;
using BackOffice.Entity.Employees;
using BackOffice.Interfaces.Base;

namespace BackOffice.Interfaces.Modules.Employees
{
    public interface IEmpSchedInfoRepository : IGenericRepository<EmpSchedInfo>
    {
        Task<EmpSchedInfo?> GetByEmpNum(Guid clientId, int empNum);
    }
}
