using BackOffice.Entity;
using BackOffice.Interfaces;
using BackOffice.Interfaces.Base;
using BackOffice.Repositories.Base;

namespace BackOffice.Repositories
{
    public class PayMethReportCatRepository(IUnitOfWork _uow)
        : GenericRepository<PayMethReportCat>(_uow),
            IPayMethReportCatRepository { }
}
