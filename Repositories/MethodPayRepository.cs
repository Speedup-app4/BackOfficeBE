using BackOffice.Entity.Payment;
using BackOffice.Interfaces;
using BackOffice.Interfaces.Base;
using BackOffice.Repositories.Base;

namespace BackOffice.Repositories
{
    public class MethodPayRepository(IUnitOfWork _uow)
        : GenericRepository<MethodPay>(_uow),
            IMethodPayRepository { }
}
