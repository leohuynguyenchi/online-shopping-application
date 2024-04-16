using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Group5_DBApp.Models;
using Microsoft.AspNetCore.Mvc;
namespace Group5_DBApp.Pages
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public class StaffDashboardModel(ILogger<StaffDashboardModel> logger, IProductService productService, DataContext context) : PageModel
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {
        private readonly ILogger<StaffDashboardModel> _logger = logger;
        private readonly IProductService _productService = productService;
        private readonly DataContext _context = context;
        public IList <Users> Users { get; set; }
        public IList<Product> Products { get; set; }

        public async Task OnGet()
        {
            // await _productService.LogProducts();
            Users = await _context.Users.ToListAsync();
            Products = await _context.Products.ToListAsync();
        }
        
        public async Task<IActionResult> OnPostModifyProductDescriptionAsync(int productId, string newProductName)
        {

            var product = await _context.Products.FindAsync(productId, newProductName);

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

        public async Task<IActionResult> OnPostModifyProductPriceAsync(int productId, string productPrice)
        {
            var product = await _context.Products.FindAsync(productId);

            if (product == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Convert the string value to decimal
            if (decimal.TryParse(productPrice, out decimal price))
            {
                product.price = price;
            }
            else
            {
                // Handle invalid input
                ModelState.AddModelError(string.Empty, "Invalid price format.");
                return Page();
            }

            _context.Products.Update(product);
            await _context.SaveChangesAsync();

            return RedirectToPage();
        }

#pragma warning disable MVC1001 // Filters cannot be applied to page handler methods
        [ValidateAntiForgeryToken]
#pragma warning restore MVC1001 // Filters cannot be applied to page handler methods
        public async Task<IActionResult> OnPostDeleteProductAsync(int productId)
        {
            var product = await _context.Products.FindAsync(productId);

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
    }
}
