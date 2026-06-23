using System.Collections.Generic;
using System.Threading.Tasks;
using BackOffice.Controllers.Attribute;
using BackOffice.Entity.System;
using BackOffice.Services.Modules.System;
using BackOffice.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace BackOffice.Controllers.Modules.System
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
