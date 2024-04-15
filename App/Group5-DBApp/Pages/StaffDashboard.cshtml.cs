using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Group5_DBApp.Models;
using Microsoft.AspNetCore.Mvc;
namespace Group5_DBApp.Pages
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public class StaffDashboardModel(ILogger<StaffDashboardModel> logger, DataContext context) : PageModel
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {
        private readonly ILogger<StaffDashboardModel> _logger = logger;
        private readonly DataContext _context = context;
        public IList <Users> Users { get; set; }
        public IList<Product> Products { get; set; }

        public async Task OnGet()
        {
            Users = await _context.Users.ToListAsync();
            Products = await _context.Products.ToListAsync();
            // Add any backend logic for the staff dashboard page here
        }
    }
}