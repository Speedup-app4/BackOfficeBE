using System.Collections.Generic;
using System.Threading.Tasks;
using BackOffice.Controllers.Attribute;
using BackOffice.Entity.Table;
using BackOffice.Services.Modules.Table;
using BackOffice.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace BackOffice.Controllers.Modules.Table
{
    [ApiController]
    [Route("api/[controller]")]
    public class TableSetupController(TableSetupService _service) : ControllerBase
    {
        [HttpGet]
        [RequireClientId]
        public async Task<IActionResult> GetAll() =>
            Ok(
                ApiResponse<IEnumerable<TableSetup>>.Ok(
                    await _service.GetAll(HttpContext.GetClientId())
                )
            );

        [HttpPost]
        [RequireClientId]
        public async Task<IActionResult> Create([FromBody] TableSetup entity) =>
            Ok(
                ApiResponse<TableSetup>.Ok(await _service.Create(HttpContext.GetClientId(), entity))
            );

        [HttpPut]
        [RequireClientId]
        public async Task<IActionResult> Update([FromBody] TableSetupUpdate entity) =>
            Ok(
                ApiResponse<TableSetup>.Ok(await _service.Update(HttpContext.GetClientId(), entity))
            );

        [HttpDelete("{tablenum}")]
        [RequireClientId]
        public async Task<IActionResult> Delete(int tablenum) =>
            Ok(ApiResponse<bool>.Ok(await _service.Delete(HttpContext.GetClientId(), tablenum)));
    }
}
