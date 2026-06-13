using BackOffice.Entity;
using BackOffice.Interfaces.Base;

namespace BackOffice.Services
{
    public class ShiftRuleService(IUnitOfWork _uow)
    {
        public async Task<IEnumerable<ShiftRule>> GetAll(Guid clientId)
        {
            return await _uow.ShiftRule.GetAllAsync(true, clientId);
        }
    }
}
