using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Group5_DBApp.Pages;

public class ProductsModel : PageModel
{
    private readonly ILogger<PrivacyModel> _logger;

    public ProductsModel(ILogger<PrivacyModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }
}

