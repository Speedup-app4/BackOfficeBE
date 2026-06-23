using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BackOffice.Entity.Coupon;
using BackOffice.Interfaces.Base;

namespace BackOffice.Interfaces.Modules.Coupon
{
    public interface IPromoGrpDetailRepository : IGenericRepository<PromoGrpDetail>
    {
        Task<IEnumerable<PromoGrpDetail>> GetByGrpId(Guid clientId, int promoGrpId);
    }
}
