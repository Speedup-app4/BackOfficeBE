using BackOffice.Entity.Menu;
using BackOffice.Interfaces;
using BackOffice.Interfaces.Base;
using BackOffice.Repositories.Base;

namespace BackOffice.Repositories
{
    public class OrderCatRepository(IUnitOfWork _uow)
        : GenericRepository<OrderCat>(_uow),
            IOrderCatRepository { }
}
