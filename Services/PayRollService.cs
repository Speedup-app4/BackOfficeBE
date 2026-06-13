using BackOffice.Entity.Employees;
using BackOffice.Interfaces.Base;

namespace BackOffice.Services
{
    public class PayRollService(IUnitOfWork _uow)
    {
        public async Task<IEnumerable<PayRoll>> GetAll(Guid clientId)
        {
            return await _uow.PayRoll.GetAllAsync(true, clientId);
        }
    }
}
