using BackOffice.Controllers.Attribute;
using BackOffice.Entity.Refund;
using BackOffice.Services;
using BackOffice.Utils;
using Microsoft.AspNetCore.Mvc;

namespace BackOffice.Controllers
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
