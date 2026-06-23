using System.Collections.Generic;
using System.Threading.Tasks;
using BackOffice.Controllers.Attribute;
using BackOffice.Entity.Station;
using BackOffice.Services.Modules.Station;
using BackOffice.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace BackOffice.Controllers.Modules.Station
{
    [ApiController]
    [Route("api/[controller]")]
    public class StationInfoController(StationInfoService _service) : ControllerBase
    {
        [HttpGet]
        [RequireClientId]
        public async Task<IActionResult> GetAll() =>
            Ok(
                ApiResponse<IEnumerable<StationInfo>>.Ok(
                    await _service.GetAll(HttpContext.GetClientId())
                )
            );

        [HttpPost]
        [RequireClientId]
        public async Task<IActionResult> Create([FromBody] StationInfo stationInfo) =>
            Ok(
                ApiResponse<StationInfo>.Ok(
                    await _service.Create(HttpContext.GetClientId(), stationInfo)
                )
            );

        [HttpPut]
        [RequireClientId]
        public async Task<IActionResult> Update([FromBody] StationInfoUpdate stationInfo) =>
            Ok(
                ApiResponse<StationInfo>.Ok(
                    await _service.Update(HttpContext.GetClientId(), stationInfo)
                )
            );
    }
}
