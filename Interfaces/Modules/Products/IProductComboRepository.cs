using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BackOffice.Entity.Products;
using BackOffice.Interfaces.Base;

namespace BackOffice.Interfaces.Modules.Products
{
    public interface IProductComboRepository : IGenericRepository<ProductCombo>
    {
        Task<IEnumerable<ProductCombo>> GetAllByProdLinkNum(Guid clientId, int prodLinkNum);
    }
}
