using Confluent.Kafka;

namespace Ecomm.Order.API.Kafka
{
    public interface IOrderProducer
    {
        Task ProduceAsync(string topic, Message<string, string> message);
    }

    public class OrderProducer : IOrderProducer
    {
        private readonly IProducer<string, string> _producer;

        public OrderProducer()
        {
            var config = new ConsumerConfig
            {
                GroupId = "order-group",
                BootstrapServers = "localhost:9092",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            _producer = new ProducerBuilder<string, string>(config).Build();
        }

        public Task ProduceAsync(string topic, Message<string, string> message)
        {
            return _producer.ProduceAsync(topic, message);
        }
    }
}
