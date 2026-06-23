using BackOffice.Entity.Report;
using BackOffice.Interfaces.Base;
using BackOffice.Interfaces.Modules.Report;
using BackOffice.Repositories.Base;

namespace BackOffice.Repositories.Modules.Report
{
    public class ReportTypeRepository(IUnitOfWork _uow)
        : GenericRepository<ReportType>(_uow),
            IReportTypeRepository { }
}
