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

        public DbSet<CreditCards> CreditCards { get; set;}  //Dbset for the CreditCard Entity

        public DbSet<Users> Users { get; set; } // Dbset for the Users entity

        public DbSet<Warehouse> Warehouse  {get; set;} // Dbset for the warehouse entity

        public DbSet<Orders> Orders { get; set; } // Dbset for the orders utility

        public DbSet<Suppliers> Suppliers { get; set; } // Dbset for the suppliers utility

        public DbSet<Stock> Stock { get; set; } // Dbset for the stock utility

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

            modelBuilder.Entity<CreditCards>().HasData(
                new CreditCards { card_id = 1, user_id = 1, card_number = "1234123412341234", expire_date = "2025-12-31"},
                new CreditCards { card_id = 2, user_id = 2, card_number = "5678567856785678", expire_date = "2025-01-31"}
            );

            modelBuilder.Entity<Users>().HasData(
                new Users { user_id = 1, user_type = "Customer", username = "John Doe"},
                new Users { user_id = 2, user_type = "Staff", username = "Dan Johnson"}
            );

            modelBuilder.Entity<Warehouse>().HasData(
                new Warehouse { warehouse_id = 1, address = "123 Main Street", capacity = 100},
                new Warehouse { warehouse_id = 2, address = "456 Elm Avenue", capacity = 75}
            );

            // need to add data for the orders, stock, and suppliers - Pipo
        }
    }
}