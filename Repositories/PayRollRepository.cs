using BackOffice.Entity.Employees;
using BackOffice.Interfaces;
using BackOffice.Interfaces.Base;
using BackOffice.Repositories.Base;

namespace BackOffice.Repositories
{
    public class PayRollRepository(IUnitOfWork _uow)
        : GenericRepository<PayRoll>(_uow),
            IPayRollRepository
    {
        public Task<PayRoll> GetByEmpNum(Guid clientId, int empNum)
        {
            throw new NotImplementedException();
        }
    }
}
