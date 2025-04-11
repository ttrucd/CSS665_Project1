using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ITAMS_App.Data;
using ITAMS_App.Models;

namespace ITAMS_App.Pages.Assets
{
    public class EditModel : PageModel
    {
        private readonly ITAMSDbContext _context;

        public EditModel(ITAMSDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Asset Asset { get; set; } = default!;

        // GET: /Assets/Edit/{id}
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Fetch the asset from the database based on the id
            var asset = await _context.Assets.FirstOrDefaultAsync(m => m.Asset_Id == id);
            if (asset == null)
            {
                return NotFound();
            }

            // Set the Asset to the fetched asset
            Asset = asset;

            return Page();
        }

      public async Task<IActionResult> OnPostAsync(int id)
{
    if (!ModelState.IsValid)
    {
        // Debugging to check if ModelState is valid or not
        Console.WriteLine("Model state is invalid");
        return Page();
    }

    if (id != Asset.Asset_Id)
    {
        return NotFound();
    }

    _context.Attach(Asset).State = EntityState.Modified;

    try
    {
        await _context.SaveChangesAsync();
        Console.WriteLine("Asset updated successfully!");
    }
    catch (DbUpdateConcurrencyException)
    {
        if (!AssetExists(Asset.Asset_Id))
        {
            return NotFound();
        }
        else
        {
            // Handle concurrency issues
            throw;
        }
    }

    return RedirectToPage("./Index");
}


        private bool AssetExists(int id)
        {
            return _context.Assets.Any(e => e.Asset_Id == id);
        }
    }
}

