using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ITAMS_App.Data;
using ITAMS_App.Models;

namespace ITAMS_App.Pages.Assets
{
    public class DeleteModel : PageModel
    {
        private readonly ITAMS_App.Data.ITAMSDbContext _context;

        public DeleteModel(ITAMS_App.Data.ITAMSDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Asset Asset { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asset = await _context.Assets.FirstOrDefaultAsync(m => m.Asset_Id == id);

            if (asset is not null)
            {
                Asset = asset;

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asset = await _context.Assets.FindAsync(id);
            if (asset != null)
    {
        try
        {
            _context.Assets.Remove(asset);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException ex)
        {
            // Check if it's a foreign key violation
            TempData["DeleteError"] = "This asset is currently assigned to an employee and cannot be deleted.";
            return RedirectToPage("./Delete", new { id = id }); // Reload delete page to show modal
        }
    }

            return RedirectToPage("./Index");
        }
    }
}
