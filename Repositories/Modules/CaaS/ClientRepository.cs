using BackOffice.Entity.CaaS;
using BackOffice.Interfaces.Base;
using BackOffice.Interfaces.Modules.CaaS;
using BackOffice.Repositories.Base;

namespace BackOffice.Repositories.Modules.CaaS
{
    public class ClientRepository(IUnitOfWork _uow)
        : GenericRepository<Client>(_uow),
            IClientRepository { }
}
