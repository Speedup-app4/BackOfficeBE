using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BackOffice.Entity.Menu;
using BackOffice.Interfaces.Base;

namespace BackOffice.Interfaces.Modules.Menu
{
    public interface IMenuOrderPosRepository : IGenericRepository<MenuOrderPos>
    {
        Task<IEnumerable<MenuOrderPos>> GetByMenuIndex(int menuIndex, Guid clientId);
    }
}
