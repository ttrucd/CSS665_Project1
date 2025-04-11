using ITAMS_App.Data;
using ITAMS_App.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ITAMS_App.Pages.MaintenanceRecords
{
    public class IndexModel : PageModel
    {
        private readonly ITAMSDbContext _context;

        public IndexModel(ITAMSDbContext context)
        {
            _context = context;
        }

        public IList<MaintenanceRecord> MaintenanceRecords { get; set; } = new List<MaintenanceRecord>();

        public async Task OnGetAsync()
        {
            MaintenanceRecords = await _context.MaintenanceRecords
                .Include(m => m.Asset)
                .ToListAsync();
        }
    }
}
