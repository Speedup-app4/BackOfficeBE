using BackOffice.Entity.Product;
using BackOffice.Interfaces;
using BackOffice.Interfaces.Base;
using BackOffice.Repositories.Base;

namespace BackOffice.Repositories
{
    public class ProductRepository(IUnitOfWork _uow)
        : GenericRepository<Product>(_uow),
            IProductRepository { }
}
