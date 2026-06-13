using BackOffice.Controllers.Attribute;
using BackOffice.Entity;
using BackOffice.Services;
using BackOffice.Utils;
using Microsoft.AspNetCore.Mvc;

namespace BackOffice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SectionController(SectionService _service) : ControllerBase
    {
        [HttpGet]
        [RequireClientId]
        public async Task<IActionResult> GetAll() =>
            Ok(
                ApiResponse<IEnumerable<Section>>.Ok(
                    await _service.GetAll(HttpContext.GetClientId())
                )
            );

        [HttpPost]
        [RequireClientId]
        public async Task<IActionResult> Create([FromBody] Section section) =>
            Ok(ApiResponse<Section>.Ok(await _service.Create(HttpContext.GetClientId(), section)));

        [HttpPut]
        [RequireClientId]
        public async Task<IActionResult> Update([FromBody] SectionUpdate section) =>
            Ok(ApiResponse<Section>.Ok(await _service.Update(HttpContext.GetClientId(), section)));
    }
}
