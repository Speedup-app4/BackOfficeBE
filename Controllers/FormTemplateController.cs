using BackOffice.Controllers.Attribute;
using BackOffice.Entity.Station;
using BackOffice.Services;
using BackOffice.Utils;
using Microsoft.AspNetCore.Mvc;

namespace BackOffice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FormTemplateController(FormTemplateService _service) : ControllerBase
    {
        [HttpGet]
        [RequireClientId]
        public async Task<IActionResult> Get() =>
            Ok(
                ApiResponse<IEnumerable<FormTemplate>>.Ok(
                    await _service.GetAll(HttpContext.GetClientId())
                )
            );
    }
}
