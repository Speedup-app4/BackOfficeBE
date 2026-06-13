using BackOffice.Controllers.Attribute;
using BackOffice.Entity;
using BackOffice.Services;
using BackOffice.Utils;
using Microsoft.AspNetCore.Mvc;

namespace BackOffice.Controllers
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
