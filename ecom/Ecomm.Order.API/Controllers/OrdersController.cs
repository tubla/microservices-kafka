using EComm.Model;
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

        [HttpPost]
        public async Task<OrderEntity> Create(OrderEntity order)
        {
            context.Orders.Add(order);
            await context.SaveChangesAsync();


            // After placing an order the quantity of the particular product should get reduced.
            // This will be achieved through kafka


            // Order will produce a message

            return order;
        }
    }
}
