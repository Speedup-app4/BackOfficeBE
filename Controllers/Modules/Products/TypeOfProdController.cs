using System.Collections.Generic;
using System.Threading.Tasks;
using BackOffice.Controllers.Attribute;
using BackOffice.Entity.Products;
using BackOffice.Services.Modules.Products;
using BackOffice.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace BackOffice.Controllers.Modules.Products
{
    [ApiController]
    [Route("api/[controller]")]
    public class TypeOfProductController(TypeOfProdService _service) : ControllerBase
    {
        [HttpGet]
        [RequireClientId]
        public async Task<IActionResult> Get() =>
            Ok(
                ApiResponse<IEnumerable<TypeOfProd>>.Ok(
                    await _service.GetAll(HttpContext.GetClientId())
                )
            );
    }
}
