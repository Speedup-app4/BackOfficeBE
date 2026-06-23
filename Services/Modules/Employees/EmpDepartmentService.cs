using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BackOffice.Entity.Employees;
using BackOffice.Interfaces.Base;

namespace BackOffice.Services.Modules.Employees
{
    public class EmpDepartmentService(IUnitOfWork _uow)
    {
        public async Task<IEnumerable<EmpDepartment>> GetAll(Guid clientId)
        {
            return await _uow.EmpDepartment.GetAllAsync(true, clientId);
        }
    }
}
