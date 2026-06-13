using BackOffice.Entity;
using BackOffice.Interfaces;
using BackOffice.Interfaces.Base;
using BackOffice.Repositories.Base;

namespace BackOffice.Repositories
{
    public class SummaryGroupRepository(IUnitOfWork _uow)
        : GenericRepository<SummaryGroup>(_uow),
            ISummaryGroupRepository { }
}
