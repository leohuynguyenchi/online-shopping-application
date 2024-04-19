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

    public async Task<IActionResult> OnPostUpdateAddressAsync(decimal userId)
    {
        var user = await _context.Users.FindAsync(userId);

        if (user == null)
        {
            return NotFound();
        }

        if (!ModelState.IsValid)
        {
            return Page();
        }

        user.home_address = Request.Form["homeAddress"];
        user.delivery_address = Request.Form["deliveryAddress"];
        user.payment_address = Request.Form["paymentAddress"];

        _context.Users.Update(user);
        await _context.SaveChangesAsync();

        return RedirectToPage();
    }

    public async Task<IActionResult> OnPostAddAddressAsync(decimal AddAddressId, string homeAddress, string deliveryAddress, string paymentAddress)
    {
        // Retrieve the user by ID
        var user = await _context.Users.FindAsync(AddAddressId);

        if (user == null)
        {
            // Handle the situation where the specified user ID doesn't exist
            // For example, return a message indicating that the user doesn't exist
            return RedirectToPage(); // Redirect to some page indicating the failure
        }

        // Update the user's addresses
        user.home_address = homeAddress;
        user.delivery_address = deliveryAddress;
        user.payment_address = paymentAddress;

        _context.Users.Update(user);
        await _context.SaveChangesAsync();

        return RedirectToPage();
    }

    public async Task<IActionResult> OnPostDeleteAddressAsync(decimal userId)
    {
        var user = await _context.Users.FindAsync(userId);

        if (user == null)
        {
            return NotFound();
        }

        if (!ModelState.IsValid)
        {
            return Page();
        }

        user.home_address = Request.Form["homeAddress"];
        user.delivery_address = Request.Form["deliveryAddress"];
        user.payment_address = Request.Form["paymentAddress"];

        _context.Users.Update(user);
        await _context.SaveChangesAsync();

        return RedirectToPage();
    }

    public async Task<IActionResult> OnPostDeleteCreditCardAsync(int creditCardId)
    {
        var creditCard = await _context.CreditCards.FindAsync(creditCardId);

        if (creditCard == null)
        {
            return NotFound();
        }

        _context.CreditCards.Remove(creditCard);
        await _context.SaveChangesAsync();

        return RedirectToPage();
    }

    public async Task<IActionResult> OnPostAddCreditCardAsync(string newCardNumber, string newExpireDate)
    {
        var maxCardId = await _context.CreditCards.MaxAsync(c => (int?)c.CardId);
            // Create a new Card object
            var newCardId = maxCardId.GetValueOrDefault() + 1;
            var newCard = new CreditCard
            {
                CardId = newCardId,
                CardNumber = newCardNumber,
                ExpireDate = newExpireDate
            };

        _context.CreditCards.Add(newCard);
        await _context.SaveChangesAsync();

        return RedirectToPage();
    }
}