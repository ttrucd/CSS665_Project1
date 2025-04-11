using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ITAMS_App.Data;
using ITAMS_App.Models;
using Microsoft.EntityFrameworkCore;

namespace ITAMS_App.Pages.Assets
{
    public class CreateModel : PageModel
    {
        private readonly ITAMSDbContext _context;

        public CreateModel(ITAMSDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Asset Asset { get; set; } = default!; // Asset to be created

        // Dropdown options for Asset Types
        public List<SelectListItem> AssetTypeOptions { get; set; } = new List<SelectListItem>();

        public async Task<IActionResult> OnGetAsync()
        {
            // Fetch all AssetTypes from the database to populate the dropdown
            AssetTypeOptions = await _context.AssetTypes
                .Select(at => new SelectListItem
                {
                    Value = at.AssetType_Id.ToString(),
                    Text = at.Type_Name
                })
                .ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page(); // If the form is invalid, redisplay the page with validation errors
            }

            // Add the new asset to the context and save changes
            _context.Assets.Add(Asset);
            await _context.SaveChangesAsync();

            // Redirect to the Index page (list of assets) after successful creation
            return RedirectToPage("./Index");
        }
    }
}
