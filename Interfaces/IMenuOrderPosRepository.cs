using BackOffice.Entity.Menu;
using BackOffice.Interfaces.Base;

namespace BackOffice.Interfaces
{
    public interface IMenuOrderPosRepository : IGenericRepository<MenuOrderPos>
    {
        Task<IEnumerable<MenuOrderPos>> GetByMenuIndex(int menuIndex, Guid clientId);
    }
}
