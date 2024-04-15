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
            await _productService.LogProducts();
            Users = await _context.Users.ToListAsync();
            Products = await _context.Products.ToListAsync();    

            try
            {
                // Retrieve users from the database
                Users = await _context.Users.ToListAsync();

                // Log information about the retrieved users
                foreach (var user in Users)
                {
                    _logger.LogInformation($"User ID: {user.user_id}, Name: {user.username}");
                }

                // Retrieve products from the database
                Products = await _context.Products.ToListAsync();

                // Log information about the retrieved products
                foreach (var product in Products)
                {
                    _logger.LogInformation($"Product ID: {product.prod_id}, Name: {product.prod_name}, Price: {product.price}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving data");
                throw; // Rethrow the exception to handle it at a higher level
            }
        }
        
        public async Task<IActionResult> OnPostModifyProductDescriptionAsync(int productId)
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

            product.prod_name = Request.Form["productName"];

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
    }
}
