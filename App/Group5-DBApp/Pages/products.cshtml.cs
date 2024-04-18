using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Group5_DBApp.Models;
using Microsoft.AspNetCore.Mvc;
namespace Group5_DBApp.Pages;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
public class ProductsModel(ILogger<ProductsModel> logger, DataContext context) : PageModel
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
{
    private readonly ILogger<ProductsModel> _logger = logger;
    private readonly DataContext _context = context;

    public IList<Product> Products { get; set; }

    public async Task OnGet()
    {
        Products = await _context.Products.ToListAsync();
    }

    public async Task<IActionResult> OnPostAddToCartAsync()
{
    // Retrieve the product ID from the form data
    var prod_id = Request.Form["prod_id"];

    // Assuming you have a way to get the current date/time, replace it with your actual implementation
    var orderDate = DateTime.Now; // Replace with your actual implementation

    // Determine the maximum order_id currently in the database
    var maxOrderId = await _context.Orders.MaxAsync(o => (int?)o.order_id);

    // Increment the max order_id to generate the new order_id
    var newOrderId = maxOrderId.GetValueOrDefault() + 1;


    // Create a new Order object
    var orderToAdd = new Orders
    {
        order_id = newOrderId,
        prod_id = Convert.ToDecimal(prod_id),
        quantity = 1, // You may need to adjust this based on your application logic
        delivery_price = 0.00M,
        delivery_type = "Ground",
        // Set other required fields as needed
    };

    // Add the new order to the Orders table
    _context.Orders.Add(orderToAdd);
    
    // Save changes to the database
    await _context.SaveChangesAsync();

    // Redirect back to the page
    return RedirectToPage("/cart");
}

}

