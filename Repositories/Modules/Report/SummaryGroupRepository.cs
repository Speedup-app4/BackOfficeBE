using BackOffice.Entity.Report;
using BackOffice.Interfaces.Base;
using BackOffice.Interfaces.Modules.Report;
using BackOffice.Repositories.Base;

namespace BackOffice.Repositories.Modules.Report
{
    public class SummaryGroupRepository(IUnitOfWork _uow)
        : GenericRepository<SummaryGroup>(_uow),
            ISummaryGroupRepository { }
}
