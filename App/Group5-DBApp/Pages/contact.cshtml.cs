using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Group5_DBApp.Pages;

public class ContactModel : PageModel
{
    private readonly ILogger<PrivacyModel> _logger;

    public ContactModel(ILogger<PrivacyModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }
}

