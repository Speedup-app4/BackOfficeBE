using BackOffice.Controllers.Attribute;
using BackOffice.Entity.Coupon;
using BackOffice.Services.Coupon;
using BackOffice.Utils;
using Microsoft.AspNetCore.Mvc;

namespace BackOffice.Controllers.Coupon
{
    [ApiController]
    [Route("api/[controller]")]
    public class PromoGrpController(PromoGrpService _service) : ControllerBase
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
