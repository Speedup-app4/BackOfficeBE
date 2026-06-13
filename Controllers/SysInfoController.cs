using BackOffice.Controllers.Attribute;
using BackOffice.Entity.System;
using BackOffice.Services;
using BackOffice.Utils;
using Microsoft.AspNetCore.Mvc;

namespace BackOffice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SysInfoController(SysInfoService _service) : ControllerBase
    {
        [HttpGet]
        [RequireClientId]
        public async Task<IActionResult> Get() =>
            Ok(
                ApiResponse<IEnumerable<SysInfo>>.Ok(
                    await _service.GetAllSysInfosAsync(HttpContext.GetClientId())
                )
            );
    }
}
