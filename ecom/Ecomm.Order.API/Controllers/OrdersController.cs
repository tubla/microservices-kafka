using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecomm.Order.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController(OrderDbContext context) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            return Ok(await context.Orders.ToListAsync());
        }
    }
}
