using BackOffice.Entity.System;
using BackOffice.Interfaces.Base;

namespace BackOffice.Services
{
    public class RevenueCenterService(IUnitOfWork _uow)
    {
        public async Task<IEnumerable<RevenueCenter>> GetAllRevenueCentersAsync(Guid clientId)
        {
            return await _uow.Revenue.GetAllAsync(true, clientId);
        }
    }
}
