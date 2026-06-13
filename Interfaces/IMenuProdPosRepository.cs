using BackOffice.Entity;
using BackOffice.Interfaces.Base;

namespace BackOffice.Interfaces
{
    public interface IMenuProdPosRepository : IGenericRepository<MenuProdPos>
    {
        Task<IEnumerable<MenuProdPos>> GetByOrderCat(int orderCat, Guid clientId);
    }
}
