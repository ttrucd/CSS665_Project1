using ITAMS_App.Data;
using ITAMS_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace ITAMS_App.Pages.MaintenanceRecords
{
    public class CreateModel : PageModel
    {
        private readonly ITAMSDbContext _context;
        

        public CreateModel(ITAMSDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public required MaintenanceRecord MaintenanceRecord { get; set; }

        public required List<SelectListItem> AssetList { get; set; }

        public async Task OnGetAsync()
        {
            // Fetch the list of assets to display in the dropdown
            AssetList = await _context.Assets
                .Select(a => new SelectListItem
                {
                    Value = a.Asset_Id.ToString(),
                    Text = a.Asset_Name
                }).ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Add the new MaintenanceRecord to the database
            _context.MaintenanceRecords.Add(MaintenanceRecord);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
