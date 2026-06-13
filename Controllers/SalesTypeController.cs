using BackOffice.Controllers.Attribute;
using BackOffice.Entity;
using BackOffice.Services;
using BackOffice.Utils;
using Microsoft.AspNetCore.Mvc;

namespace BackOffice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesTypeController(SalesTypeService _service) : ControllerBase
    {
        [HttpGet]
        [RequireClientId]
        public async Task<IActionResult> GetAll() =>
            Ok(
                ApiResponse<IEnumerable<SalesType>>.Ok(
                    await _service.GetAll(HttpContext.GetClientId())
                )
            );

        [HttpPost]
        [RequireClientId]
        public async Task<IActionResult> Create([FromBody] SalesType salesType) =>
            Ok(
                ApiResponse<SalesType>.Ok(
                    await _service.Create(HttpContext.GetClientId(), salesType)
                )
            );

        [HttpPut]
        [RequireClientId]
        public async Task<IActionResult> Update([FromBody] SalesTypeUpdate salesType) =>
            Ok(
                ApiResponse<SalesType>.Ok(
                    await _service.Update(HttpContext.GetClientId(), salesType)
                )
            );
    }
}
