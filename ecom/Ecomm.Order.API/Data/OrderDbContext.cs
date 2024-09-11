using Microsoft.EntityFrameworkCore;
using OrderEntity = EComm.Model.Order;

namespace Ecomm.Order.API
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            SQLitePCL.raw.SetProvider(new SQLitePCL.SQLite3Provider_e_sqlite3());
            Database.EnsureCreated();
        }

        public DbSet<OrderEntity> Orders { get; set; }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<OrderEntity>().HasData(new OrderEntity() { Id = 1, CustomerName = "Rohit", ProductId = 1, Quantity = 15 });
        //    modelBuilder.Entity<OrderEntity>().HasData(new OrderEntity() { Id = 2, CustomerName = "David", ProductId = 2, Quantity = 20 });
        //    modelBuilder.Entity<OrderEntity>().HasData(new OrderEntity() { Id = 3, CustomerName = "Anirudh", ProductId = 3, Quantity = 5 });
        //    modelBuilder.Entity<OrderEntity>().HasData(new OrderEntity() { Id = 4, CustomerName = "Jackson", ProductId = 4, Quantity = 10 });
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
