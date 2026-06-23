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

        [HttpPut]
        [RequireClientId]
        public async Task<IActionResult> Update([FromBody] EmployeeUpdate updateDto) =>
            Ok(
                ApiResponse<Employee>.Ok(
                    await _service.Update(HttpContext.GetClientId(), updateDto)
                )
            );
    }
}
