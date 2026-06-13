using BackOffice.Controllers.Attribute;
using BackOffice.Entity.Employees;
using BackOffice.Services;
using BackOffice.Utils;
using Microsoft.AspNetCore.Mvc;

namespace BackOffice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController(EmployeeService _service) : ControllerBase
    {
        [HttpGet]
        [RequireClientId]
        public async Task<IActionResult> Get([FromQuery] int? EmpNum) =>
            Ok(
                ApiResponse<IEnumerable<Employee>>.Ok(
                    await _service.Get(HttpContext.GetClientId(), EmpNum)
                )
            );

        [HttpPost]
        [RequireClientId]
        public async Task<IActionResult> Create([FromBody] Employee employee) =>
            Ok(
                ApiResponse<Employee>.Ok(await _service.Create(HttpContext.GetClientId(), employee))
            );
    }
}
