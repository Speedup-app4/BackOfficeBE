using BackOffice.Controllers.Attribute;
using BackOffice.Entity;
using BackOffice.Services;
using BackOffice.Utils;
using Microsoft.AspNetCore.Mvc;

namespace BackOffice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SummaryGroupController(SummaryGroupService _service) : ControllerBase
    {
        [HttpGet]
        [RequireClientId]
        public async Task<IActionResult> GetAll() =>
            Ok(
                ApiResponse<IEnumerable<SummaryGroup>>.Ok(
                    await _service.GetAll(HttpContext.GetClientId())
                )
            );

        [HttpPost]
        [RequireClientId]
        public async Task<IActionResult> Create([FromBody] SummaryGroup summaryGroup) =>
            Ok(
                ApiResponse<SummaryGroup>.Ok(
                    await _service.Create(HttpContext.GetClientId(), summaryGroup)
                )
            );

        [HttpPut]
        [RequireClientId]
        public async Task<IActionResult> Update([FromBody] SummaryGroupUpdate summaryGroup) =>
            Ok(
                ApiResponse<SummaryGroup>.Ok(
                    await _service.Update(HttpContext.GetClientId(), summaryGroup)
                )
            );
    }
}
