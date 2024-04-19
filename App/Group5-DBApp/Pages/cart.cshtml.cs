using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Group5_DBApp.Models;
using Microsoft.AspNetCore.Mvc;
namespace Group5_DBApp.Pages;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
public class CartModel(ILogger<CartModel> logger, DataContext context) : PageModel
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
{
    private readonly ILogger<CartModel> _logger = logger;
    private readonly DataContext _context = context;

    public IList<Orders> Orders { get; set; }
    public IList<Product> Products { get; set; }
    public IList<Users> Users { get; set; }
    public IList<CreditCard> CreditCards { get; set; }
    public async Task OnGet()
    {
        Orders = await _context.Orders.ToListAsync();
        Products = await _context.Products.ToArrayAsync();
        Users = await _context.Users.ToListAsync();
        CreditCards = await _context.CreditCards.ToArrayAsync();
    }

    public async Task<IActionResult> OnPostDeleteOrderAsync(decimal orderId)
    {
        // Implement logic to delete the order with the given orderId from the cart
        var orderToDelete = await _context.Orders.FindAsync(orderId);
        
        if (orderToDelete != null)
        {
            _context.Orders.Remove(orderToDelete);
            await _context.SaveChangesAsync();
        }
        else
        {
            // Handle case where the order to delete was not found
            return NotFound();
        }

        // Optionally, you can redirect the user back to the cart page or perform any other desired action
        return RedirectToPage();
    }

}