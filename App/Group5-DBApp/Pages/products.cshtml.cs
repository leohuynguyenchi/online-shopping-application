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
    public IList<Stock> Stock { get; set; }
    public async Task OnGet()
    {
        Products = await _context.Products.ToListAsync();
        Stock = await _context.Stock.ToArrayAsync();
    }

    public async Task<IActionResult> OnPostAddToCartAsync()
    {
        // Retrieve the product ID and quantity from the form data
        var prod_id = Request.Form["prod_id"];
        var quantity = Request.Form["quantity"];
        var deliveryType = Request.Form["delivery"];
        var quantityValue = Convert.ToDecimal(Request.Form["quantity"].FirstOrDefault());

        // Parse the product ID to decimal
        if (!decimal.TryParse(prod_id, out decimal productId))
        {
            // Handle the case where the product ID cannot be parsed
            return BadRequest("Invalid product ID");
        }

        // Retrieve the product from the database using its ID
        var product = await _context.Products.FindAsync(productId);
        var stock = await _context.Stock.FirstOrDefaultAsync(s => s.prod_id == product.prod_id);
        
        if (product == null)
        {
            return NotFound();
        }

        if (stock == null)
        {
            return BadRequest("Stock not found");
        }

        if (quantityValue == 0)
        {
            return BadRequest("Invalid quantity value");
        }

        // Calculate the total price by multiplying the product price with the quantity
        var totalPrice = product.price * Convert.ToDecimal(quantity);

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
            prod_id = productId,
            quantity = Convert.ToInt64(quantity), // You may need to adjust this based on your application logic
            delivery_price = totalPrice,
            delivery_type = deliveryType,
            // Set other required fields as needed
        };

        
        // Check if there is enough stock available
        if (stock.quantity < quantityValue)
        {
            // Handle the case where there is not enough stock available
            return BadRequest("Not enough stock available. Available quantity: " + stock.quantity);
        }

        // Add the new order to the Orders table
        _context.Orders.Add(orderToAdd);

        // Deduct the ordered quantity from the product's stock
        stock.quantity -= quantityValue;
        // Save changes to the database
        await _context.SaveChangesAsync();

        // Redirect back to the page
        return RedirectToPage("/cart");
    }

}