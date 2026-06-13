using BackOffice.Entity.Menu;
using BackOffice.Interfaces;
using BackOffice.Interfaces.Base;
using BackOffice.Repositories.Base;

namespace BackOffice.Repositories
{
    public class MultiMenuNamesRepository(IUnitOfWork _uow)
        : GenericRepository<MultiMenuNames>(_uow),
            IMultiMenuNamesRepository { }
}
