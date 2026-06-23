using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BackOffice.Entity.Coupon;
using BackOffice.Interfaces.Base;

namespace BackOffice.Interfaces.Modules.Coupon
{
    public interface IPromoReportCatRepository : IGenericRepository<PromoReportCat>
    {
        Task<IEnumerable<PromoReportCat>> GetByPromoNum(Guid clientId, int promoNum);
    }
}
