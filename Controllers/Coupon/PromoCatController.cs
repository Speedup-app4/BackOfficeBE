using BackOffice.Controllers.Attribute;
using BackOffice.Entity.Coupon;
using BackOffice.Services.Coupon;
using BackOffice.Utils;
using Microsoft.AspNetCore.Mvc;

namespace BackOffice.Controllers.Coupon
{
    [ApiController]
    [Route("api/[controller]")]
    public class PromoCatController(PromoCatService _service) : ControllerBase
    {
        [HttpGet]
        [RequireClientId]
        public async Task<IActionResult> Get() =>
            Ok(
                ApiResponse<IEnumerable<PromoCat>>.Ok(
                    await _service.GetAll(HttpContext.GetClientId())
                )
            );
    }
}
