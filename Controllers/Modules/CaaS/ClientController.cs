using System;
using System.Threading.Tasks;
using BackOffice.Controllers.Attribute;
using BackOffice.Entity.CaaS;
using BackOffice.Entity.Employees;
using BackOffice.Services.Modules.CaaS;
using BackOffice.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace BackOffice.Controllers.Modules.CaaS
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController(ClientService _service) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] Guid clientId) =>
            Ok(ApiResponse<Client>.Ok(await _service.Get(clientId)));

        [HttpPost("login")]
        [RequireClientId]
        public async Task<IActionResult> Login([FromQuery] string swipe) =>
            Ok(ApiResponse<Employee>.Ok(await _service.Login(HttpContext.GetClientId(), swipe)));
    }
}
