using BackOffice.Entity.Products;
using BackOffice.Interfaces.Base;
using BackOffice.Interfaces.Modules.Products;
using BackOffice.Repositories.Base;

namespace BackOffice.Repositories.Modules.Products
{
    public class ProductRepository(IUnitOfWork _uow)
        : GenericRepository<Product>(_uow),
            IProductRepository { }
}
