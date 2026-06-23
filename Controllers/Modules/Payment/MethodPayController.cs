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
    public class MethodPayController(MethodPayService _service) : ControllerBase
    {
        [HttpGet]
        [RequireClientId]
        public async Task<IActionResult> GetAll() =>
            Ok(
                ApiResponse<IEnumerable<MethodPay>>.Ok(
                    await _service.GetAll(HttpContext.GetClientId())
                )
            );

        [HttpPost]
        [RequireClientId]
        public async Task<IActionResult> Create([FromBody] MethodPay methodPay) =>
            Ok(
                ApiResponse<MethodPay>.Ok(
                    await _service.Create(HttpContext.GetClientId(), methodPay)
                )
            );

        [HttpPut]
        [RequireClientId]
        public async Task<IActionResult> Update([FromBody] MethodPayUpdate methodPay) =>
            Ok(
                ApiResponse<MethodPay>.Ok(
                    await _service.Update(HttpContext.GetClientId(), methodPay)
                )
            );
    }
}
