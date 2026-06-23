using BackOffice.Entity.Payment;
using BackOffice.Interfaces.Base;
using BackOffice.Interfaces.Modules.Payment;
using BackOffice.Repositories.Base;

namespace BackOffice.Repositories.Modules.Payment
{
    public class PayMethReportCatRepository(IUnitOfWork _uow)
        : GenericRepository<PayMethReportCat>(_uow),
            IPayMethReportCatRepository { }
}
