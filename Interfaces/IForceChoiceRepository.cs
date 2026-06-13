using BackOffice.Entity.Products;
using BackOffice.Interfaces.Base;

namespace BackOffice.Interfaces
{
    public interface IForceChoiceRepository : IGenericRepository<ForceChoice>
    {
        Task<IEnumerable<ForceChoice>> GetAllByQuestion(Guid clientId, int optionIndex);
    }
}
