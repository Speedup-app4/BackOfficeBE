using BackOffice.Entity.Coupon;
using BackOffice.Interfaces.Base;
using BackOffice.Interfaces.Coupon;
using BackOffice.Repositories.Base;

namespace BackOffice.Repositories.Coupon
{
    public class PromoCatRepository(IUnitOfWork _uow)
        : GenericRepository<PromoCat>(_uow),
            IPromoCatRepository { }
}
