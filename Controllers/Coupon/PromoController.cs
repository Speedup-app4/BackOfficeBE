using BackOffice.Controllers.Attribute;
using BackOffice.Entity.Coupon;
using BackOffice.Services.Coupon;
using BackOffice.Utils;
using Microsoft.AspNetCore.Mvc;

namespace BackOffice.Controllers.Coupon
{
    [ApiController]
    [Route("api/[controller]")]
    public class PromoController(PromoService _service) : ControllerBase
    {
        [HttpGet]
        [RequireClientId]
        public async Task<IActionResult> Get([FromQuery] int? PromoGrpId = null) =>
            Ok(
                ApiResponse<IEnumerable<Promo>>.Ok(
                    await _service.Get(HttpContext.GetClientId(), PromoGrpId)
                )
            );

        [HttpPost]
        [RequireClientId]
        public async Task<IActionResult> Create([FromBody] Promo promo) =>
            Ok(ApiResponse<Promo>.Ok(await _service.Create(HttpContext.GetClientId(), promo)));

        [HttpPut]
        [RequireClientId]
        public async Task<IActionResult> Update([FromBody] PromoUpdate promo) =>
            Ok(ApiResponse<Promo>.Ok(await _service.Update(HttpContext.GetClientId(), promo)));
    }
}
