using BackOffice.Entity.Menu;
using BackOffice.Interfaces.Base;
using BackOffice.Interfaces.Modules.Menu;
using BackOffice.Repositories.Base;

namespace BackOffice.Repositories.Modules.Menu
{
    public class MultiMenuNameRepository(IUnitOfWork _uow)
        : GenericRepository<MultiMenuName>(_uow),
            IMultiMenuNameRepository { }
}
