using Confluent.Kafka;
using Ecomm.Order.API.Kafka;
using EComm.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Ecomm.Order.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController(OrderDbContext context, IOrderProducer orderProducer) : ControllerBase
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


            await orderProducer.ProduceAsync("order-topic", new Message<string, string>
            {
                Key = order.Id.ToString(),
                Value = JsonConvert.SerializeObject(order)
            });

            return order;
        }
    }
}
