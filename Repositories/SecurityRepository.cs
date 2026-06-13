using BackOffice.Entity;
using BackOffice.Interfaces;
using BackOffice.Interfaces.Base;
using BackOffice.Repositories.Base;

namespace BackOffice.Repositories
{
    public class SecurityRepository(IUnitOfWork _uow)
        : GenericRepository<Security>(_uow),
            ISecurityRepository { }
}
