using System.Collections.Generic;
using System.Threading.Tasks;
using BackOffice.Controllers.Attribute;
using BackOffice.Entity.Payment;
using BackOffice.Services.Modules.Payment;
using BackOffice.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace BackOffice.Controllers.Modules.Payment
{
    [ApiController]
    [Route("api/[controller]")]
    public class PayMethReportCatController(PayMethReportCatService _service) : ControllerBase
    {
        [HttpGet]
        [RequireClientId]
        public async Task<IActionResult> Get() =>
            Ok(
                ApiResponse<IEnumerable<PayMethReportCat>>.Ok(
                    await _service.GetAll(HttpContext.GetClientId())
                )
            );
    }
}
