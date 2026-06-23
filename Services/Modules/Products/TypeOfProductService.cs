using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BackOffice.Entity.Products;
using BackOffice.Interfaces.Base;

namespace BackOffice.Services.Modules.Products
{
    public class TypeOfProdService(IUnitOfWork _uow)
    {
        public async Task<IEnumerable<TypeOfProd>> GetAll(Guid clientId)
        {
            return await _uow.TypeOfProd.GetAllAsync(true, clientId);
        }
    }
}
