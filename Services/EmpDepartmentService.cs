using BackOffice.Entity.Employees;
using BackOffice.Interfaces.Base;

namespace BackOffice.Services
{
    public class EmpDepartmentService(IUnitOfWork _uow)
    {
        public async Task<IEnumerable<EmpDepartment>> GetAll(Guid clientId)
        {
            return await _uow.EmpDepartment.GetAllAsync(true, clientId);
        }
    }
}
