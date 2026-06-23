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
    public class ReportTypeController(ReportTypeService _service) : ControllerBase
    {
        [HttpGet]
        [RequireClientId]
        public async Task<IActionResult> GetAll() =>
            Ok(
                ApiResponse<IEnumerable<ReportType>>.Ok(
                    await _service.GetAll(HttpContext.GetClientId())
                )
            );

        [HttpPut]
        [RequireClientId]
        public async Task<IActionResult> Update(
            [FromBody] IEnumerable<ReportTypeUpdate> reportType
        ) =>
            Ok(
                ApiResponse<IEnumerable<ReportType>>.Ok(
                    await _service.Update(HttpContext.GetClientId(), reportType)
                )
            );
    }
}
