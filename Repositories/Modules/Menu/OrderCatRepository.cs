using BackOffice.Entity.Menu;
using BackOffice.Interfaces.Base;
using BackOffice.Interfaces.Modules.Menu;
using BackOffice.Repositories.Base;

namespace BackOffice.Repositories.Modules.Menu
{
    public class OrderCatRepository(IUnitOfWork _uow)
        : GenericRepository<OrderCat>(_uow),
            IOrderCatRepository { }
}
