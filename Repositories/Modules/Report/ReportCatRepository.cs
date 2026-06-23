using BackOffice.Entity.Report;
using BackOffice.Interfaces.Base;
using BackOffice.Interfaces.Modules.Report;
using BackOffice.Repositories.Base;

namespace BackOffice.Repositories.Modules.Report
{
    public class ReportCatRepository(IUnitOfWork _uow)
        : GenericRepository<ReportCat>(_uow),
            IReportCatRepository { }
}
