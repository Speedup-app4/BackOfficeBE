using BackOffice.Entity.Coupon;
using BackOffice.Interfaces.Base;

namespace BackOffice.Services.Coupon
{
    public class PromoCatService(IUnitOfWork _uow)
    {
        public async Task<IEnumerable<PromoCat>> GetAll(Guid clientId)
        {
            return await _uow.PromoCat.GetAllAsync(true, clientId);
        }
    }
}
