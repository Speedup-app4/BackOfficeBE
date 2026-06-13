using BackOffice.Controllers.Attribute;
using BackOffice.Entity.System;
using BackOffice.Services;
using BackOffice.Utils;
using Microsoft.AspNetCore.Mvc;

namespace BackOffice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RevenueCenterController(RevenueCenterService _service) : ControllerBase
    {
        [HttpGet]
        [RequireClientId]
        public async Task<IActionResult> GetRevenueCenterInfo() =>
            Ok(
                ApiResponse<IEnumerable<RevenueCenter>>.Ok(
                    await _service.GetAllRevenueCentersAsync(HttpContext.GetClientId())
                )
            );
    }
}
