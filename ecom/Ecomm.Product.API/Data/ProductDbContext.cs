using EComm.Model;
using Microsoft.EntityFrameworkCore;

namespace Ecomm.Product.API
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            SQLitePCL.raw.SetProvider(new SQLitePCL.SQLite3Provider_e_sqlite3());
            Database.EnsureCreated();
        }

        public DbSet<ProductEntity> Products { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductEntity>().HasData(new ProductEntity() { Id = 1, Name = "IPhone12", Price = 50000, Quantity = 15 });
            modelBuilder.Entity<ProductEntity>().HasData(new ProductEntity() { Id = 2, Name = "Dell Laptop", Price = 150000, Quantity = 5 });
            modelBuilder.Entity<ProductEntity>().HasData(new ProductEntity() { Id = 3, Name = "Nikon Z50", Price = 98000, Quantity = 20 });
            modelBuilder.Entity<ProductEntity>().HasData(new ProductEntity() { Id = 4, Name = "IPad Air", Price = 125000, Quantity = 12 });
            base.OnModelCreating(modelBuilder);
        }
    }
}
