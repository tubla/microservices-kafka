﻿namespace EComm.Model
{
    public class ProductEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
