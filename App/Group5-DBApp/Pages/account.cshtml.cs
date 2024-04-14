using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Group5_DBApp.Models;
using Microsoft.AspNetCore.Mvc;
namespace Group5_DBApp.Pages;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
public class AccountModel(ILogger<AccountModel> logger, DataContext context) : PageModel
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
{
    private readonly ILogger<AccountModel> _logger = logger;
    private readonly DataContext _context = context;

    public IList<CreditCard> CreditCards { get; set; }
    public IList <Users> Users { get; set; }
    public async Task OnGet()
    {
        CreditCards = await _context.CreditCards.ToListAsync();
        Users = await _context.Users.ToListAsync();
    }
    public async Task<IActionResult> OnPostUpdateCreditCardAsync(int creditCardId)
    {
        var creditCard = await _context.CreditCards.FindAsync(creditCardId);

        if (creditCard == null)
        {
            return NotFound();
        }

        if (!ModelState.IsValid)
        {
            return Page();
        }

        creditCard.CardNumber = Request.Form["CardNumber"];
        creditCard.ExpireDate = Request.Form["ExpireDate"];

        _context.CreditCards.Update(creditCard);
        await _context.SaveChangesAsync();

        return RedirectToPage();
    }

    // public async Task<IActionResult> OnPostUpdateAddressAsync(int user_id)
    // {
    //     var user = await _context.Users.FindAsync(user_id);

    //     if (creditCard == null)
    //     {
    //         return NotFound();
    //     }

    //     if (!ModelState.IsValid)
    //     {
    //         return Page();
    //     }

    //     creditCard.CardNumber = Request.Form["CardNumber"];
    //     creditCard.ExpireDate = Request.Form["ExpireDate"];

    //     _context.CreditCards.Update(creditCard);
    //     await _context.SaveChangesAsync();

    //     return RedirectToPage();
    // }
}