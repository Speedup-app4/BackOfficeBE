using BackOffice.Entity.Products;
using BackOffice.Interfaces;
using BackOffice.Interfaces.Base;
using BackOffice.Repositories.Base;
using Dapper;

namespace BackOffice.Repositories
{
    public class ForceChoiceRepository(IUnitOfWork _uow)
        : GenericRepository<ForceChoice>(_uow),
            IForceChoiceRepository
    {
        public Task<IEnumerable<ForceChoice>> GetAllByQuestion(Guid clientId, int optionIndex)
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
