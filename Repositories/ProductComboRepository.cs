using BackOffice.Entity.Product;
using BackOffice.Interfaces;
using BackOffice.Interfaces.Base;
using BackOffice.Repositories.Base;
using Dapper;

namespace BackOffice.Repositories
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
