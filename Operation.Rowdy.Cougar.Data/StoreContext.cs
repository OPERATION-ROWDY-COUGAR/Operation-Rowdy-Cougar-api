using Operation.Rowdy.Cougar.Domain.Catalog;
using Microsoft.EntityFrameworkCore;
namespace Operation.Rowdy.Cougar.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {}

        public DbSet<Item> Items { get; set; }
       
    }
}


