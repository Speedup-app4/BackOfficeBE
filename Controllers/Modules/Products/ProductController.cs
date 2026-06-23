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
    public class ProductController(ProductService _service) : ControllerBase
    {
        [HttpGet]
        [RequireClientId]
        public async Task<IActionResult> Get([FromQuery] int? ProdNum) =>
            Ok(
                ApiResponse<IEnumerable<Product>>.Ok(
                    await _service.Get(HttpContext.GetClientId(), ProdNum)
                )
            );

        [HttpPost]
        [RequireClientId]
        public async Task<IActionResult> Create([FromBody] Product product) =>
            Ok(ApiResponse<Product>.Ok(await _service.Create(HttpContext.GetClientId(), product)));

        [HttpPut]
        [RequireClientId]
        public async Task<IActionResult> Update([FromBody] ProductUpdate product) =>
            Ok(ApiResponse<Product>.Ok(await _service.Update(HttpContext.GetClientId(), product)));
    }
}
