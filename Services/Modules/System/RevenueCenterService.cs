using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BackOffice.Entity.System;
using BackOffice.Interfaces.Base;

namespace BackOffice.Services.Modules.System
{
    public class RevenueCenterService(IUnitOfWork _uow)
    {
        public async Task<IEnumerable<RevenueCenter>> GetAllRevenueCentersAsync(Guid clientId)
        {
            return await _uow.Revenue.GetAllAsync(true, clientId);
        }
    }
}
