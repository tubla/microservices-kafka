using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecomm.Product.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(ProductDbContext context) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            return Ok(await context.Products.ToListAsync());
        }
    }
}
