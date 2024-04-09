using Microsoft.EntityFrameworkCore;
namespace Group5_DBApp.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}
        public DbSet<Product> Products { get; set; } // DbSet for Product entity
    }
}