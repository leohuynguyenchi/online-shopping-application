using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Group5_DBApp.Models;
namespace Group5_DBApp.Pages;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
public class IndexModel(ILogger<IndexModel> logger, DataContext context) : PageModel
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
{
    private readonly ILogger<IndexModel> _logger = logger;
    private readonly DataContext _context = context;
    public IList<Product> Products { get; set; }

    public async Task OnGet()
    {
        Products = await _context.Products.ToListAsync();
    }
}