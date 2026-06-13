using BackOffice.Entity.Product;
using BackOffice.Interfaces.Base;

namespace BackOffice.Services
{
    public class TypeOfProdService(IUnitOfWork _uow)
    {
        public async Task<IEnumerable<TypeOfProd>> GetAll(Guid clientId)
        {
            return await _uow.TypeOfProd.GetAllAsync(true, clientId);
        }
    }
}
