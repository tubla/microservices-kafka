using EComm.Model;
using Microsoft.EntityFrameworkCore;

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
    }
}
