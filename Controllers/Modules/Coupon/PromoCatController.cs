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
