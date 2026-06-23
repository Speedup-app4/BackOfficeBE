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
    public class SecurityController(SecurityService _service) : ControllerBase
    {
        [HttpGet]
        [RequireClientId]
        public async Task<IActionResult> GetAll() =>
            Ok(
                ApiResponse<IEnumerable<Security>>.Ok(
                    await _service.GetAll(HttpContext.GetClientId())
                )
            );

        [HttpPut]
        [RequireClientId]
        public async Task<IActionResult> Update([FromBody] SecurityUpdate security) =>
            Ok(
                ApiResponse<Security>.Ok(await _service.Update(HttpContext.GetClientId(), security))
            );
    }
}
