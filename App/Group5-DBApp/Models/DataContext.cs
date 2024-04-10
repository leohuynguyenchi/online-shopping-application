using Microsoft.EntityFrameworkCore;
namespace Group5_DBApp.Models
{
    public class DataContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DataContext(DbContextOptions<DataContext> options, IConfiguration configuration) : base(options){
            _configuration = configuration;
        }
        public DbSet<Product> Products { get; set; } // DbSet for Product entity
        public string? DbPath {get;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured){
                optionsBuilder.UseSqlite(_configuration.GetConnectionString("DefaultConnection"));
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasData(
                new Product { prod_id = 1, prod_name = "Wilson Evolution Indoor Basketball", price = 59.99M },
                new Product { prod_id = 2, prod_name = "Spalding NBA Street Outdoor Basketball", price = 29.99M },
                new Product { prod_id = 3, prod_name = "Nike Elite Championship Basketball", price = 89.99M },
                new Product { prod_id = 4, prod_name = "Under Armour 495 Indoor/Outdoor Basketball", price = 39.99M },
                new Product { prod_id = 5, prod_name = "Molten BGG Composite Basketball", price = 44.99M }
            );
        }
    }
}