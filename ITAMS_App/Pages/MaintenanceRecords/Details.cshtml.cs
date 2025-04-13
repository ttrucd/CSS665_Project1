using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ITAMS_App.Data;
using ITAMS_App.Models;

namespace ITAMS_App.Pages.MaintenanceRecords
{
    public class DetailsModel : PageModel
    {
        private readonly ITAMSDbContext _context;

        public DetailsModel(ITAMSDbContext context)
        {
            _context = context;
        }

        // Property to hold the record details
        public MaintenanceRecord? MaintenanceRecord { get; set; }

        // GET handler to retrieve record by ID
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
                return NotFound(); // No ID provided

            // Fetch the MaintenanceRecord with related Asset and AssetType
            MaintenanceRecord = await _context.MaintenanceRecords
                .Include(m => m.Asset)
                .ThenInclude(a => a.AssetType)
                .FirstOrDefaultAsync(m => m.Record_Id == id);

            if (MaintenanceRecord == null)
                return NotFound(); // Record not found

            return Page(); // Render the details page
        }
    }
}
