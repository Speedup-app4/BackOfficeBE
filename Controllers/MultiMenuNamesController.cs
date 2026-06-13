using BackOffice.Controllers.Attribute;
using BackOffice.Entity.Menu;
using BackOffice.Services;
using BackOffice.Utils;
using Microsoft.AspNetCore.Mvc;

namespace BackOffice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MultiMenuNamesController(MultiMenuNamesService _service) : ControllerBase
    {
        [HttpGet]
        [RequireClientId]
        public async Task<IActionResult> GetAll() =>
            Ok(
                ApiResponse<IEnumerable<MultiMenuNames>>.Ok(
                    await _service.GetAll(HttpContext.GetClientId())
                )
            );

        [HttpPost]
        [RequireClientId]
        public async Task<IActionResult> Create([FromBody] MultiMenuNames multiMenuNames) =>
            Ok(
                ApiResponse<MultiMenuNames>.Ok(
                    await _service.Create(HttpContext.GetClientId(), multiMenuNames)
                )
            );

        [HttpPut]
        [RequireClientId]
        public async Task<IActionResult> Update([FromBody] MultiMenuNamesUpdate multiMenuNames) =>
            Ok(
                ApiResponse<MultiMenuNames>.Ok(
                    await _service.Update(HttpContext.GetClientId(), multiMenuNames)
                )
            );
    }
}
