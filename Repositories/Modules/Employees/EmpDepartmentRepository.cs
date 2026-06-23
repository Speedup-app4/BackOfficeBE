using BackOffice.Entity.Employees;
using BackOffice.Interfaces.Base;
using BackOffice.Interfaces.Modules.Employees;
using BackOffice.Repositories.Base;

namespace BackOffice.Repositories.Modules.Employees
{
    public class EmpDepartmentRepository(IUnitOfWork _uow)
        : GenericRepository<EmpDepartment>(_uow),
            IEmpDepartmentRepository { }
}
