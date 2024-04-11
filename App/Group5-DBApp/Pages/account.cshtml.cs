using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Group5_DBApp.Models;
namespace Group5_DBApp.Pages;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
public class AccountModel(ILogger<AccountModel> logger, DataContext context) : PageModel
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
{
    private readonly ILogger<AccountModel> _logger = logger;
    private readonly DataContext _context = context;

    public IList<CreditCards> CreditCards { get; set; }

    public async Task OnGet()
    {
        //CreditCards = await _context.CreditCards.ToListAsync();
    }
}

