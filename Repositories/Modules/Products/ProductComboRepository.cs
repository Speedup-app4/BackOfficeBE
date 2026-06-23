using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BackOffice.Entity.Products;
using BackOffice.Interfaces.Base;
using BackOffice.Interfaces.Modules.Products;
using BackOffice.Repositories.Base;
using Dapper;

namespace BackOffice.Repositories.Modules.Products
{
    public class ProductComboRepository(IUnitOfWork _uow)
        : GenericRepository<ProductCombo>(_uow),
            IProductComboRepository
    {
        public Task<IEnumerable<ProductCombo>> GetAllByProdLinkNum(Guid clientId, int prodLinkNum)
        {
            var query =
                @"
                SELECT *
                FROM ""ProductCombo""
                WHERE ""ClientId"" = @ClientId AND ""ProdLinkNum"" = @ProdLinkNum";
            var parameters = new { ClientId = clientId, ProdLinkNum = prodLinkNum };

            return _uow.Connection.QueryAsync<ProductCombo>(query, parameters);
        }
    }
}
