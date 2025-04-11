using ITAMS_App.Data;
using ITAMS_App.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ITAMS_App.Pages.Employees 
{
    public class IndexModel : PageModel
    {
        private readonly ITAMSDbContext _context;

        public IndexModel(ITAMSDbContext context)
        {
            _context = context;
        }
        public List<Employee> Employees {get; set;} = new();

        public async Task OnGetAsync() {
            Employees = await _context.Employees
                .Include(e => e.AssignedAsset)
                .ToListAsync();
        }

    }
}