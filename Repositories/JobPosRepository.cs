using BackOffice.Entity.Employees;
using BackOffice.Interfaces;
using BackOffice.Interfaces.Base;
using BackOffice.Repositories.Base;

namespace BackOffice.Repositories
{
    public class JobPosRepository(IUnitOfWork _uow)
        : GenericRepository<JobPos>(_uow),
            IJobPosRepository { }
}
