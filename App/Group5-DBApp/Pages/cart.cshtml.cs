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
    public async Task OnGet()
    {
        Orders = await _context.Orders.ToListAsync();
        Products = await _context.Products.ToArrayAsync();
    }
}