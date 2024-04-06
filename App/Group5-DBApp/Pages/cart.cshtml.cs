using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Group5_DBApp.Pages;
public class CartModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public CartModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }
}
