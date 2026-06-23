using BackOffice.Entity.Coupon;
using BackOffice.Interfaces.Base;
using BackOffice.Interfaces.Modules.Coupon;
using BackOffice.Repositories.Base;

namespace BackOffice.Repositories.Modules.Coupon
{
    public class PromoRepository(IUnitOfWork _uow)
        : GenericRepository<Promo>(_uow),
            IPromoRepository { }
}
