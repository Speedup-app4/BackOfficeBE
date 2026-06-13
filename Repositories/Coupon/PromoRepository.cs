using BackOffice.Entity.Coupon;
using BackOffice.Interfaces.Base;
using BackOffice.Interfaces.Coupon;
using BackOffice.Repositories.Base;

namespace BackOffice.Repositories.Coupon
{
    public class PromoRepository(IUnitOfWork _uow)
        : GenericRepository<Promo>(_uow),
            IPromoRepository { }
}
