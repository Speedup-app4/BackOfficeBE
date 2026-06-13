using BackOffice.Controllers.Attribute;
using BackOffice.Entity.Product;
using BackOffice.Services;
using BackOffice.Utils;
using Microsoft.AspNetCore.Mvc;

namespace BackOffice.Controllers
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
