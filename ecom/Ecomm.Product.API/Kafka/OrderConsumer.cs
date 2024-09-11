
using Confluent.Kafka;
using EComm.Model;
using Newtonsoft.Json;

namespace Ecomm.Product.API.Kafka
{
    public class OrderConsumer(IServiceScopeFactory scopeFactory) : BackgroundService
    {
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            return Task.Run(() => ConsumeAsync("order-topic", stoppingToken), stoppingToken);
        }

        public async Task ConsumeAsync(string topic, CancellationToken cancellationToken)
        {
            var config = new ConsumerConfig
            {
                GroupId = "order-group",
                BootstrapServers = "localhost:9092",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            using var consumer = new ConsumerBuilder<string, string>(config).Build();
            consumer.Subscribe(topic);

            while (!cancellationToken.IsCancellationRequested)
            {
                var consumeResult = consumer.Consume(cancellationToken);

                // get order details
                var order = JsonConvert.DeserializeObject<OrderEntity>(consumeResult.Message.Value);

                // update product quantity in db
                using var scope = scopeFactory.CreateScope();
                var dbContext = scope.ServiceProvider.GetRequiredService<ProductDbContext>();

                var product = await dbContext.Products.FindAsync(order?.ProductId);
                if (product != null)
                {
                    product.Quantity -= order!.Quantity;
                    await dbContext.SaveChangesAsync();
                }

            }
            consumer.Close();

        }
    }
}
