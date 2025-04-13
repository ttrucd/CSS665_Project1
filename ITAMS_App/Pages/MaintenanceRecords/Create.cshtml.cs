using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITAMS_App.Data;
using ITAMS_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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
        public MaintenanceRecord MaintenanceRecord { get; set; } = default!; // MaintenanceRecord to be created

        // Dropdown options
        public List<SelectListItem> AssetList { get; set; } = new(); // Asset dropdown list

        public async Task<IActionResult> OnGetAsync()
        {
            // Fetch all assets to populate the dropdown for asset selection
            AssetList = await _context.Assets
                .Select(a => new SelectListItem
                {
                    Value = a.Asset_Id.ToString(),
                    Text = a.AssetType != null ? a.AssetType.Type_Name : "Unknown Type" // Handle potential null values
                })
                .ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                // If there are validation errors, rebuild the Asset dropdown
                AssetList = await _context.Assets
                    .Select(a => new SelectListItem
                    {
                        Value = a.Asset_Id.ToString(),
                        Text = a.AssetType != null ? a.AssetType.Type_Name : "Unknown Type"
                    })
                    .ToListAsync();

                return Page();
            }

            // Add the new maintenance record to the database
            _context.MaintenanceRecords.Add(MaintenanceRecord);
            await _context.SaveChangesAsync();

            // Redirect back to the list page
            return RedirectToPage("./Index");
        }
    }
}
