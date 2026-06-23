using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BackOffice.Entity.Menu;
using BackOffice.Interfaces.Base;

namespace BackOffice.Interfaces.Modules.Menu
{
    public interface IMenuProdPosRepository : IGenericRepository<MenuProdPos>
    {
        Task<IEnumerable<MenuProdPos>> GetByOrderCat(int orderCat, Guid clientId);
    }
}
