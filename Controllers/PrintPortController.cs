using BackOffice.Controllers.Attribute;
using BackOffice.Entity.System;
using BackOffice.Services;
using BackOffice.Utils;
using Microsoft.AspNetCore.Mvc;

namespace BackOffice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrintPortController(PrintPortService _service) : ControllerBase
    {
        [HttpGet]
        [RequireClientId]
        public async Task<IActionResult> Get() =>
            Ok(
                ApiResponse<IEnumerable<PrintPort>>.Ok(
                    await _service.GetAll(HttpContext.GetClientId())
                )
            );
    }
}
