using System.Collections.Generic;
using System.Threading.Tasks;
using BackOffice.Controllers.Attribute;
using BackOffice.Entity.Coupon;
using BackOffice.Services.Modules.Coupon;
using BackOffice.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace BackOffice.Controllers.Modules.Coupon
{
    [ApiController]
    [Route("api/[controller]")]
    public class PromoGroupController(PromoGrpService _service) : ControllerBase
    {
        [HttpGet]
        [RequireClientId]
        public async Task<IActionResult> Get([FromQuery] int? PromoGrpId = null) =>
            Ok(
                ApiResponse<IEnumerable<PromoGrp>>.Ok(
                    await _service.Get(HttpContext.GetClientId(), PromoGrpId)
                )
            );

        [HttpPost]
        [RequireClientId]
        public async Task<IActionResult> Create([FromBody] PromoGrp promoGrp) =>
            Ok(
                ApiResponse<PromoGrp>.Ok(await _service.Create(HttpContext.GetClientId(), promoGrp))
            );

        [HttpPut]
        [RequireClientId]
        public async Task<IActionResult> Update([FromBody] PromoGrpUpdate promoGrp) =>
            Ok(
                ApiResponse<PromoGrp>.Ok(await _service.Update(HttpContext.GetClientId(), promoGrp))
            );
    }
}
