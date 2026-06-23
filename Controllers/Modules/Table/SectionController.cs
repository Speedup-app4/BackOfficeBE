using System.Collections.Generic;
using System.Threading.Tasks;
using BackOffice.Controllers.Attribute;
using BackOffice.Entity.Table;
using BackOffice.Services.Modules.Table;
using BackOffice.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace BackOffice.Controllers.Modules.Table
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
