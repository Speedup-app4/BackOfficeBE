using BackOffice.Controllers.Attribute;
using BackOffice.Entity.Report;
using BackOffice.Services;
using BackOffice.Utils;
using Microsoft.AspNetCore.Mvc;

namespace BackOffice.Controllers
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
    }
}
