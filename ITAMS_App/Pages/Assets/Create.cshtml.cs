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
        public List<SelectListItem> AssetTypeOptions { get; set; } = new();

        public IActionResult OnGet()
        {
            // Fetch all AssetTypes from the database to populate the dropdown
            AssetTypeOptions = _context.AssetTypes
                .Select(at => new SelectListItem
                {
                    Value = at.AssetType_Id.ToString(),
                    Text = at.Type_Name
                })
                .ToList();


            return Page();
        }

       public async Task<IActionResult> OnPostAsync()
{

    if (!ModelState.IsValid)
    {
        foreach (var modelError in ModelState.Values.SelectMany(v => v.Errors))
        {
            Console.WriteLine($"Validation Error: {modelError.ErrorMessage}");
        }
        // Rebuild dropdown in case of form errors
        AssetTypeOptions = _context.AssetTypes
        .Select(a => new SelectListItem
        {
            Value = a.AssetType_Id.ToString(),
            Text = a.Type_Name
        }).ToList();

        return Page();
    }

    _context.Assets.Add(Asset);
    await _context.SaveChangesAsync();

    return RedirectToPage("./Index");
}



    }
}
