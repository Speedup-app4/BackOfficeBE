using BackOffice.Entity.Employees;
using BackOffice.Interfaces;
using BackOffice.Interfaces.Base;
using BackOffice.Repositories.Base;

namespace BackOffice.Repositories
{
    public class EmpDepartmentRepository(IUnitOfWork _uow)
        : GenericRepository<EmpDepartment>(_uow),
            IEmpDepartmentRepository { }
}
