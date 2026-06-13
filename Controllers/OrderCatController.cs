using BackOffice.Controllers.Attribute;
using BackOffice.Entity.Menu;
using BackOffice.Services;
using BackOffice.Utils;
using Microsoft.AspNetCore.Mvc;

namespace BackOffice.Controllers
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
