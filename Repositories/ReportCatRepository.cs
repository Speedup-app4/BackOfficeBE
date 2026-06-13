using BackOffice.Entity.Report;
using BackOffice.Interfaces;
using BackOffice.Interfaces.Base;
using BackOffice.Repositories.Base;

namespace BackOffice.Repositories
{
    public class ReportCatRepository(IUnitOfWork _uow)
        : GenericRepository<ReportCat>(_uow),
            IReportCatRepository { }
}
