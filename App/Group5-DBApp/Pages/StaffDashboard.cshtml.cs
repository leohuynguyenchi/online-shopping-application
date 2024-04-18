using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Group5_DBApp.Models;
using Microsoft.AspNetCore.Mvc;
namespace Group5_DBApp.Pages
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public class StaffDashboardModel(ILogger<StaffDashboardModel> logger, DataContext context) : PageModel
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {
        private readonly ILogger<StaffDashboardModel> _logger = logger;
        // private readonly IProductService _productService = productService;
        private readonly DataContext _context = context;
        public IList <Users> Users { get; set; }
        public IList<Product> Products { get; set; }
        public IList<Stock> Stock { get; set; }
        public IList<Warehouse> Warehouse { get; set; }

        public async Task OnGet()
        {
            // await _productService.LogProducts();
            Users = await _context.Users.ToListAsync();
            Products = await _context.Products.ToListAsync();
            Stock = await _context.Stock.ToListAsync();
            Warehouse = await _context.Warehouse.ToListAsync();
        }
        
        public async Task<IActionResult> OnPostUpdateProductNameAsync(decimal productIdToUpdate, string newProductName)
        {
            var product = await _context.Products.FindAsync(productIdToUpdate);

            if (product == null)
            {                
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            product.prod_name = newProductName;

            _context.Products.Update(product);
            await _context.SaveChangesAsync();

            return RedirectToPage();
        }
        public async Task<IActionResult> OnPostUpdateProductPriceAsync(decimal productIdToUpdatePrice, int newPrice)
        {
            var product = await _context.Products.FindAsync(productIdToUpdatePrice);

            if (product == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return Page();
            }

            product.price = newPrice;

            _context.Products.Update(product);
            await _context.SaveChangesAsync();

            return RedirectToPage();
        }

// #pragma warning disable MVC1001 // Filters cannot be applied to page handler methods
        // [ValidateAntiForgeryToken]
// #pragma warning restore MVC1001 // Filters cannot be applied to page handler methods
        public async Task<IActionResult> OnPostDeleteProductAsync(decimal productIdToDelete)
        {
            var product = await _context.Products.FindAsync(productIdToDelete);

            if (product == null)
            {
                return NotFound();
            }
            
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return RedirectToPage();
        }
        public async Task<IActionResult> OnPostAddProductAsync(string productName, decimal productPrice)
        {
            var maxProdId = await _context.Products.MaxAsync(p => (int?)p.prod_id);
            // Create a new Product object
            var newProdId = maxProdId.GetValueOrDefault() + 1;
            var newProduct = new Product
            {
                prod_id = newProdId,
                prod_name = productName,
                price = productPrice
            };

            // Add the new product to the database (database will assign prod_id)
            _context.Products.Add(newProduct);
            await _context.SaveChangesAsync();

            // Redirect back to the page
            return RedirectToPage();
        }
        public async Task<IActionResult> OnPostAddStockToWarehouseAsync(decimal prodId, decimal warehouseId, decimal quantity)
        {
            // Check if the product exists
            var product = await _context.Products.FirstOrDefaultAsync(p => p.prod_id == prodId);
            if (product == null)
            {
                return NotFound($"Product with ID {prodId} not found.");
            }

            // Check if the warehouse exists
            var warehouse = await _context.Warehouse.FirstOrDefaultAsync(w => w.warehouse_id == warehouseId);
            if (warehouse == null)
            {
                return NotFound($"Warehouse with ID {warehouseId} not found.");
            }

            // Check if adding this quantity exceeds warehouse capacity (optional)
            if (warehouse.capacity.HasValue && warehouse.capacity.Value < quantity)
            {
                return BadRequest("Adding this quantity exceeds warehouse capacity.");
            }
            warehouse.capacity -= quantity;
            var maxStockId = await _context.Stock.MaxAsync(s => (int?)s.stock_id);
            // Create a new Product object
            var newStockId = maxStockId.GetValueOrDefault() + 1;
            // Create a new stock record
            var newStock = new Stock
            {
                stock_id = newStockId,
                prod_id = prodId,
                warehouse_id = warehouseId,
                quantity = quantity
            };

            // Add the new stock to the database
            _context.Stock.Add(newStock);
            await _context.SaveChangesAsync();

            return RedirectToPage(); // Redirect back to the page after adding stock
        }
    }
}
