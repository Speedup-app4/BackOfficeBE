using BackOffice.Entity.Coupon;
using BackOffice.Interfaces.Base;

namespace BackOffice.Interfaces.Coupon
{
    public interface IPromoReportCatRepository : IGenericRepository<PromoReportCat>
    {
        Task<IEnumerable<PromoReportCat>> GetByPromoNum(Guid clientId, int promoNum);
    }
}
