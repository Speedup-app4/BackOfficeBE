using BackOffice.Entity.Product;
using BackOffice.Interfaces.Base;

namespace BackOffice.Interfaces
{
    public interface IProductComboRepository : IGenericRepository<ProductCombo>
    {
        Task<IEnumerable<ProductCombo>> GetAllByProdLinkNum(Guid clientId, int prodLinkNum);
    }
}
