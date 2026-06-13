using BackOffice.Entity;
using BackOffice.Interfaces;
using BackOffice.Interfaces.Base;
using BackOffice.Repositories.Base;

namespace BackOffice.Repositories
{
    public class SalesTypeRepository(IUnitOfWork _uow)
        : GenericRepository<SalesType>(_uow),
            ISalesTypeRepository { }
}
