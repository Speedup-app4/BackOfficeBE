using BackOffice.Entity.Product;
using BackOffice.Interfaces;
using BackOffice.Interfaces.Base;
using BackOffice.Repositories.Base;

namespace BackOffice.Repositories
{
    public class TypeOfProdRepository(IUnitOfWork _uow)
        : GenericRepository<TypeOfProd>(_uow),
            ITypeOfProdRepository { }
}
