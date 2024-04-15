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

        public DbSet<CreditCard> CreditCards { get; set;}  //Dbset for the CreditCard Entity

        public DbSet<Users> Users { get; set; } // Dbset for the Users entity

        public DbSet<Warehouse> Warehouse  {get; set;} // Dbset for the warehouse entity

        public DbSet<Orders> Orders { get; set; } // Dbset for the orders utility

        public DbSet<Suppliers> Suppliers { get; set; } // Dbset for the suppliers utility

        public DbSet<Stock> Stock { get; set; } // Dbset for the stock utility

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

            modelBuilder.Entity<CreditCard>().HasData(
                new CreditCard { CardId = 1, UserId = 1, CardNumber = "1234123412341234", ExpireDate = "2025-12-31"},
                new CreditCard { CardId = 2, UserId = 2, CardNumber = "5678567856785678", ExpireDate = "2025-01-31"}
            );

            modelBuilder.Entity<Users>().HasData(
                new Users { user_id = 1, user_type = "Customer", username = "John Doe", home_address = "123 Main St, Anytown, USA", delivery_address = "123 Main St, Anytown, USA", payment_address = "123 Main St, Anytown, USA"},
                new Users { user_id = 2, user_type = "Customer", username = "Jane Smith", home_address = "456 Elm St, Somecity, USA", delivery_address = "456 Elm St, Somecity, USA", payment_address = "456 Elm St, Somecity, USA"},
                new Users { user_id = 3, user_type = "Staff", username = "Dan Johnson", salary = 60000, job_title = "Manager", home_address = "789 Oak St, Othercity, USA"},
                new Users { user_id = 4, user_type = "Staff", username = "Bob Williams", salary = 45000, job_title = "Sales Associate", home_address = "321 Pine St, Anothercity, USA"}
            );

            modelBuilder.Entity<Warehouse>().HasData(
                new Warehouse { warehouse_id = 1, address = "123 Main Street", capacity = 100},
                new Warehouse { warehouse_id = 2, address = "456 Elm Avenue", capacity = 75}
            );

            modelBuilder.Entity<Stock>().HasData(
                new Stock { stock_id = 1, prod_id = 1, warehouse_id = 1, quantity = 50},
                new Stock { stock_id = 2, prod_id = 2, warehouse_id = 2, quantity = 50}
            );

            modelBuilder.Entity<Suppliers>().HasData(
                new Suppliers { sup_id = 1, name = "Supplier A", prod_id = 1, price = 25.99M, address = "789 Oak Street"},
                new Suppliers { sup_id = 2, name = "Supplier B", prod_id = 2, price = 89.99M, address = "101 Maple Avenue"}
            );
        }
    }
}