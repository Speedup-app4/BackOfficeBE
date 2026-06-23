using BackOffice.Entity.Refund;
using BackOffice.Interfaces.Base;
using BackOffice.Interfaces.Modules.Refund;
using BackOffice.Repositories.Base;

namespace BackOffice.Repositories.Modules.Refund
{
    public class RefundReasonRepository(IUnitOfWork _uow)
        : GenericRepository<RefundReason>(_uow),
            IRefundReasonRepository { }
}
