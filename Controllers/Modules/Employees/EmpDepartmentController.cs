using System.Collections.Generic;
using System.Threading.Tasks;
using BackOffice.Controllers.Attribute;
using BackOffice.Entity.Employees;
using BackOffice.Services.Modules.Employees;
using BackOffice.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace BackOffice.Controllers.Modules.Employees
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpDepartmentController(EmpDepartmentService _service) : ControllerBase
    {
        [HttpGet]
        [RequireClientId]
        public async Task<IActionResult> Get() =>
            Ok(
                ApiResponse<IEnumerable<EmpDepartment>>.Ok(
                    await _service.GetAll(HttpContext.GetClientId())
                )
            );
    }
}
