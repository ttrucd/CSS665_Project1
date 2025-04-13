using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public List<SelectListItem> StatusOptions { get; set; } = new();

        private void PopulateStatusOptions()
        {
            StatusOptions = Enum.GetValues(typeof(AssetStatus))
                .Cast<AssetStatus>()
                .Select(s => new SelectListItem
                {
                    Value = s.ToString(),
                    Text = s.ToString().Replace("UnderMaintenance", "Under Maintenance")
                                       .Replace("InUse", "In Use")
                })
                .ToList();
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            // Fetch the asset from the database
        Asset = await _context.Assets
            .Include(a => a.AssetType)  // Ensure AssetType is included
            .FirstOrDefaultAsync(m => m.Asset_Id == id);

            // Check if the asset is null
            if (Asset == null)
            {
            return NotFound();
            }

            ViewData["AssetTypeList"] = new SelectList(
                _context.AssetTypes.ToList(),
                "AssetType_Id",
                "Type_Name",
                Asset.AssetType_Id
            );

            PopulateStatusOptions();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                ViewData["AssetTypeList"] = new SelectList(
                    _context.AssetTypes.ToList(),
                    "AssetType_Id",
                    "Type_Name",
                    Asset.AssetType_Id
                );

                PopulateStatusOptions();
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
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Assets.Any(e => e.Asset_Id == Asset.Asset_Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }
    }
}
