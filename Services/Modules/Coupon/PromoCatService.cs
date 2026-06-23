using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BackOffice.Entity.Coupon;
using BackOffice.Interfaces.Base;

namespace BackOffice.Services.Modules.Coupon
{
    public class PromoCatService(IUnitOfWork _uow)
    {
        public async Task<IEnumerable<PromoCat>> GetAll(Guid clientId)
        {
            return await _uow.PromoCat.GetAllAsync(true, clientId);
        }
    }
}
