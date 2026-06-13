using BackOffice.Entity.Employees;
using BackOffice.Interfaces.Base;

namespace BackOffice.Interfaces
{
    public interface IEmpSchedInfoRepository : IGenericRepository<EmpSchedInfo>
    {
        Task<EmpSchedInfo?> GetByEmpNum(Guid clientId, int empNum);
    }
}
