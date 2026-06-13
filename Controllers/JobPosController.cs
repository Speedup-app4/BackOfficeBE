using BackOffice.Controllers.Attribute;
using BackOffice.Entity.Employees;
using BackOffice.Services;
using BackOffice.Utils;
using Microsoft.AspNetCore.Mvc;

namespace BackOffice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobPosController(JobPosService _service) : ControllerBase
    {
        [HttpGet]
        [RequireClientId]
        public async Task<IActionResult> GetAll() =>
            Ok(
                ApiResponse<IEnumerable<JobPos>>.Ok(
                    await _service.GetAll(HttpContext.GetClientId())
                )
            );

        [HttpPost]
        [RequireClientId]
        public async Task<IActionResult> Create([FromBody] JobPos jobPos) =>
            Ok(ApiResponse<JobPos>.Ok(await _service.Create(HttpContext.GetClientId(), jobPos)));

        [HttpPut]
        [RequireClientId]
        public async Task<IActionResult> Update([FromBody] JobPosUpdate jobPos) =>
            Ok(ApiResponse<JobPos>.Ok(await _service.Update(HttpContext.GetClientId(), jobPos)));
    }
}
