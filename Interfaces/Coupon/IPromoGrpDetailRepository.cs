using BackOffice.Entity.Coupon;
using BackOffice.Interfaces.Base;

namespace BackOffice.Interfaces.Coupon
{
    public interface IPromoGrpDetailRepository : IGenericRepository<PromoGrpDetail>
    {
        Task<IEnumerable<PromoGrpDetail>> GetByGrpId(Guid clientId, int promoGrpId);
    }
}
