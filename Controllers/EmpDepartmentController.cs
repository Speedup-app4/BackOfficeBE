using BackOffice.Controllers.Attribute;
using BackOffice.Entity.Employees;
using BackOffice.Services;
using BackOffice.Utils;
using Microsoft.AspNetCore.Mvc;

namespace BackOffice.Controllers
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
