using BackOffice.Controllers.Attribute;
using BackOffice.Entity;
using BackOffice.Services;
using BackOffice.Utils;
using Microsoft.AspNetCore.Mvc;

namespace BackOffice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MenuProdPosController(MenuProdPosService _service) : ControllerBase
    {
        [HttpGet]
        [RequireClientId]
        public async Task<IActionResult> Get(
            [FromQuery] int? menuIndex,
            [FromQuery] bool? isGetOrderCat = false
        ) =>
            Ok(
                ApiResponse<IEnumerable<MenuProdPos>>.Ok(
                    await _service.Get(HttpContext.GetClientId(), menuIndex, isGetOrderCat)
                )
            );
    }
}
