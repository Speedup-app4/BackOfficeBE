using System.Collections.Generic;
using System.Threading.Tasks;
using BackOffice.Controllers.Attribute;
using BackOffice.Entity.Menu;
using BackOffice.Services.Modules.Menu;
using BackOffice.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace BackOffice.Controllers.Modules.Menu
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
