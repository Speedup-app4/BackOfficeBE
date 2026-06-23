using System.Collections.Generic;
using System.Threading.Tasks;
using BackOffice.Controllers.Attribute;
using BackOffice.Entity.Report;
using BackOffice.Services.Modules.Report;
using BackOffice.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace BackOffice.Controllers.Modules.Report
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
