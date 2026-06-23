using System.Collections.Generic;
using System.Threading.Tasks;
using BackOffice.Controllers.Attribute;
using BackOffice.Entity.System;
using BackOffice.Services.Modules.System;
using BackOffice.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace BackOffice.Controllers.Modules.System
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesTypeController(SalesTypeService _service) : ControllerBase
    {
        [HttpGet]
        [RequireClientId]
        public async Task<IActionResult> GetAll() =>
            Ok(
                ApiResponse<IEnumerable<SalesType>>.Ok(
                    await _service.GetAll(HttpContext.GetClientId())
                )
            );

        [HttpPost]
        [RequireClientId]
        public async Task<IActionResult> Create([FromBody] SalesType salesType) =>
            Ok(
                ApiResponse<SalesType>.Ok(
                    await _service.Create(HttpContext.GetClientId(), salesType)
                )
            );

        [HttpPut]
        [RequireClientId]
        public async Task<IActionResult> Update([FromBody] SalesTypeUpdate salesType) =>
            Ok(
                ApiResponse<SalesType>.Ok(
                    await _service.Update(HttpContext.GetClientId(), salesType)
                )
            );
    }
}
