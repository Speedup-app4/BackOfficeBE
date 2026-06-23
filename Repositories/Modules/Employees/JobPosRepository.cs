using BackOffice.Entity.Employees;
using BackOffice.Interfaces.Base;
using BackOffice.Interfaces.Modules.Employees;
using BackOffice.Repositories.Base;

namespace BackOffice.Repositories.Modules.Employees
{
    public class JobPosRepository(IUnitOfWork _uow)
        : GenericRepository<JobPos>(_uow),
            IJobPosRepository { }
}
