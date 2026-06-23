using System.Collections.Generic;
using System.Threading.Tasks;
using BackOffice.Controllers.Attribute;
using BackOffice.Entity.Menu;
using BackOffice.Services.Modules.Menu;
using BackOffice.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace BackOffice.Controllers.Modules.Menu
{
    [ApiController]
    [Route("api/[controller]")]
    public class MultiMenuNameController(MultiMenuNameService _service) : ControllerBase
    {
        [HttpGet]
        [RequireClientId]
        public async Task<IActionResult> GetAll() =>
            Ok(
                ApiResponse<IEnumerable<MultiMenuName>>.Ok(
                    await _service.GetAll(HttpContext.GetClientId())
                )
            );

        [HttpPost]
        [RequireClientId]
        public async Task<IActionResult> Create([FromBody] MultiMenuName multiMenuName) =>
            Ok(
                ApiResponse<MultiMenuName>.Ok(
                    await _service.Create(HttpContext.GetClientId(), multiMenuName)
                )
            );

        [HttpPut]
        [RequireClientId]
        public async Task<IActionResult> Update(
            [FromBody] MultiMenuNameUpdate multiMenuNameUpdate
        ) =>
            Ok(
                ApiResponse<MultiMenuName>.Ok(
                    await _service.Update(HttpContext.GetClientId(), multiMenuNameUpdate)
                )
            );

        [HttpPut("setup")]
        [RequireClientId]
        public async Task<IActionResult> UpdateMenu([FromBody] MenuSetup menuSetup) =>
            Ok(
                ApiResponse<MenuSetup>.Ok(
                    await _service.UpdateMenu(HttpContext.GetClientId(), menuSetup)
                )
            );
    }
}
