using BackOffice.Entity.Refund;
using BackOffice.Interfaces;
using BackOffice.Interfaces.Base;
using BackOffice.Repositories.Base;

namespace BackOffice.Repositories
{
    public class RefundReasonRepository(IUnitOfWork _uow)
        : GenericRepository<RefundReason>(_uow),
            IRefundReasonRepository { }
}
