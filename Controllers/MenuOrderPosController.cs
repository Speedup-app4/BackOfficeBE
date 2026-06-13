using BackOffice.Controllers.Attribute;
using BackOffice.Entity.Menu;
using BackOffice.Services;
using BackOffice.Utils;
using Microsoft.AspNetCore.Mvc;

namespace BackOffice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MenuOrderPosController(MenuOrderPosService _service) : ControllerBase
    {
        [HttpGet]
        [RequireClientId]
        public async Task<IActionResult> Get(
            [FromQuery] int? menuIndex,
            [FromQuery] bool? isGetOrderCat = false
        ) =>
            Ok(
                ApiResponse<IEnumerable<MenuOrderPos>>.Ok(
                    await _service.Get(HttpContext.GetClientId(), menuIndex, isGetOrderCat)
                )
            );
    }
}
