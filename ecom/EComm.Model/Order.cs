namespace EComm.Model
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerName { get; set; } = default!;

        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
    }
}
