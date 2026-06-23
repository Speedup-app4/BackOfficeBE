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
    public class ForceChoiceRepository(IUnitOfWork _uow)
        : GenericRepository<ForceChoice>(_uow),
            IForceChoiceRepository
    {
        public Task<IEnumerable<ForceChoice>> GetAllByOptionIndex(Guid clientId, int optionIndex)
        {
            var query =
                @"
                SELECT *
                FROM ""ForcedChoices""
                WHERE ""ClientId"" = @ClientId AND ""OPTIONINDEX"" = @OptionIndex";
            var parameters = new { ClientId = clientId, OptionIndex = optionIndex };

            return _uow.Connection.QueryAsync<ForceChoice>(query, parameters);
        }
    }
}
