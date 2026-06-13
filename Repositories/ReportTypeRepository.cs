using BackOffice.Entity.Report;
using BackOffice.Interfaces;
using BackOffice.Interfaces.Base;
using BackOffice.Repositories.Base;

namespace BackOffice.Repositories
{
    public class ReportTypeRepository(IUnitOfWork _uow)
        : GenericRepository<ReportType>(_uow),
            IReportTypeRepository { }
}
