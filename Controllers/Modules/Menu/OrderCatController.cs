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
    public class OrderCatController(OrderCatService _service) : ControllerBase
    {
        [HttpGet]
        [RequireClientId]
        public async Task<IActionResult> GetAll() =>
            Ok(
                ApiResponse<IEnumerable<OrderCat>>.Ok(
                    await _service.GetAll(HttpContext.GetClientId())
                )
            );

        [HttpPost]
        [RequireClientId]
        public async Task<IActionResult> Create([FromBody] OrderCat orderCat) =>
            Ok(
                ApiResponse<OrderCat>.Ok(await _service.Create(HttpContext.GetClientId(), orderCat))
            );

        [HttpPut]
        [RequireClientId]
        public async Task<IActionResult> Update([FromBody] OrderCatUpdate orderCat) =>
            Ok(
                ApiResponse<OrderCat>.Ok(await _service.Update(HttpContext.GetClientId(), orderCat))
            );
    }
}
