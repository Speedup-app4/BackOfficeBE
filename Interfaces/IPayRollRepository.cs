using BackOffice.Entity.Employees;
using BackOffice.Interfaces.Base;

namespace BackOffice.Interfaces
{
    public interface IPayRollRepository : IGenericRepository<PayRoll>
    {
        Task<PayRoll> GetByEmpNum(Guid clientId, int empNum);
    }
}
