using BackOffice.Entity.Coupon;
using BackOffice.Interfaces.Base;
using BackOffice.Interfaces.Coupon;
using BackOffice.Repositories.Base;

namespace BackOffice.Repositories.Coupon
{
    public class PromoGrpRepository(IUnitOfWork _uow)
        : GenericRepository<PromoGrp>(_uow),
            IPromoGrpRepository { }
}
