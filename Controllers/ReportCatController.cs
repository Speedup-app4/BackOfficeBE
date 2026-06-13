using BackOffice.Controllers.Attribute;
using BackOffice.Entity.Report;
using BackOffice.Services;
using BackOffice.Utils;
using Microsoft.AspNetCore.Mvc;

namespace BackOffice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportCatController(ReportCatService _service) : ControllerBase
    {
        [HttpGet]
        [RequireClientId]
        public async Task<IActionResult> GetAll() =>
            Ok(
                ApiResponse<IEnumerable<ReportCat>>.Ok(
                    await _service.GetAll(HttpContext.GetClientId())
                )
            );

        [HttpPost]
        [RequireClientId]
        public async Task<IActionResult> Create([FromBody] ReportCat reportCat) =>
            Ok(
                ApiResponse<ReportCat>.Ok(
                    await _service.Create(HttpContext.GetClientId(), reportCat)
                )
            );

        [HttpPut]
        [RequireClientId]
        public async Task<IActionResult> Update([FromBody] ReportCatUpdate reportCat) =>
            Ok(
                ApiResponse<ReportCat>.Ok(
                    await _service.Update(HttpContext.GetClientId(), reportCat)
                )
            );
    }
}
