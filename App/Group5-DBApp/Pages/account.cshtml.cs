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
    public IActionResult OnPostLogin(string username)
    {
        // Check if the user exists in the database and determine their role
        var user = _context.Users.FirstOrDefault(u => u.username == username);
        
        if (user != null)
        {
            // Determine the role of the user
            if (user.user_type == "Customer")
            {
                // Redirect the customer to the customer dashboard
                return RedirectToPage("/CustomerDashboard");
            }
            else if (user.user_type == "Staff")
            {
                // Redirect the staff to the staff dashboard
                return RedirectToPage("/StaffDashboard");
            }
        }

        // If the user is not found or the username is incorrect, show an error message
        ModelState.AddModelError(string.Empty, "Invalid username");
        return Page();
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
}