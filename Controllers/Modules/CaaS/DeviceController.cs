using System.Collections.Generic;
using System.Threading.Tasks;
using BackOffice.Controllers.Attribute;
using BackOffice.Entity.CaaS;
using BackOffice.Services.Modules.CaaS;
using BackOffice.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace BackOffice.Controllers.Modules.CaaS
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeviceController(DeviceService _service) : ControllerBase
    {
        [HttpGet]
        [RequireClientId]
        public async Task<IActionResult> GetAll() =>
            Ok(
                ApiResponse<IEnumerable<Device>>.Ok(
                    await _service.GetAll(HttpContext.GetClientId())
                )
            );

        [HttpPut]
        [RequireClientId]
        public async Task<IActionResult> Update(DeviceUpdate device) =>
            Ok(ApiResponse<Device>.Ok(await _service.Update(HttpContext.GetClientId(), device)));
    }
}
