using System.Collections.Generic;
using System.Threading.Tasks;
using BackOffice.Controllers.Attribute;
using BackOffice.Entity.Refund;
using BackOffice.Services.Modules.Refund;
using BackOffice.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace BackOffice.Controllers.Modules.Refund
{
    [ApiController]
    [Route("api/[controller]")]
    public class RefundReasonController(RefundReasonService _service) : ControllerBase
    {
        [HttpGet]
        [RequireClientId]
        public async Task<IActionResult> GetAll() =>
            Ok(
                ApiResponse<IEnumerable<RefundReason>>.Ok(
                    await _service.GetAll(HttpContext.GetClientId())
                )
            );

        [HttpPost]
        [RequireClientId]
        public async Task<IActionResult> Create([FromBody] RefundReason refundReason) =>
            Ok(
                ApiResponse<RefundReason>.Ok(
                    await _service.Create(HttpContext.GetClientId(), refundReason)
                )
            );

        [HttpPut]
        [RequireClientId]
        public async Task<IActionResult> Update([FromBody] RefundReasonUpdate refundReason) =>
            Ok(
                ApiResponse<RefundReason>.Ok(
                    await _service.Update(HttpContext.GetClientId(), refundReason)
                )
            );
    }
}
