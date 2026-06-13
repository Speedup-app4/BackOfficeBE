using BackOffice.Controllers.Attribute;
using BackOffice.Entity.Products;
using BackOffice.Services;
using BackOffice.Utils;
using Microsoft.AspNetCore.Mvc;

namespace BackOffice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionController(QuestionService _service) : ControllerBase
    {
        [HttpGet]
        [RequireClientId]
        public async Task<IActionResult> Get([FromQuery] int? optionIndex) =>
            Ok(
                ApiResponse<IEnumerable<Question>>.Ok(
                    await _service.Get(HttpContext.GetClientId(), optionIndex)
                )
            );

        [HttpPost]
        [RequireClientId]
        public async Task<IActionResult> Create([FromBody] Question question) =>
            Ok(
                ApiResponse<Question>.Ok(await _service.Create(HttpContext.GetClientId(), question))
            );

        [HttpPut]
        [RequireClientId]
        public async Task<IActionResult> Update([FromBody] QuestionUpdate question) =>
            Ok(
                ApiResponse<Question>.Ok(await _service.Update(HttpContext.GetClientId(), question))
            );
    }
}
