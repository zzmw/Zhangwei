using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;

namespace order
{
    public class OrderDbContext: DbContext{
        public OrderDbContext(DbContextOptions<OrderDbContext> options)
            :base(options)
        {
        }
        public DbSet<Item> Items{get;set;}
    }
}