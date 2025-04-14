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
    public List<SelectListItem> StatusOptions { get; set; } = new();


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

        // Populate Status dropdown using the AssetStatus enum
        StatusOptions = Enum.GetValues(typeof(AssetStatus))
            .Cast<AssetStatus>()
            .Select(s => new SelectListItem
            {
                Value = s.ToString(),
                Text = s.ToString().Replace("UnderMaintenance", "Under Maintenance")
                                   .Replace("InUse", "In Use")
            })
            .ToList();

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            // Rebuild dropdown in case of form errors
            AssetTypeOptions = _context.AssetTypes
                .Select(a => new SelectListItem
                {
                    Value = a.AssetType_Id.ToString(),
                    Text = a.Type_Name
                })      
                .ToList();

            StatusOptions = Enum.GetValues(typeof(AssetStatus))
                .Cast<AssetStatus>()
                .Select(s => new SelectListItem
                {
                    Value = s.ToString(),
                    Text = s.ToString().Replace("UnderMaintenance", "Under Maintenance")
                                       .Replace("InUse", "In Use")
                })
                .ToList();

            return Page();
        }

          // Ensure the status is correctly mapped to the enum
        if (Enum.TryParse<AssetStatus>(Asset.Status.ToString().Replace(" ", ""), out var status))
        {
        Asset.Status = status;
        }

        try
    {
        _context.Assets.Add(Asset);
        await _context.SaveChangesAsync();
        return RedirectToPage("./Index");
    }
    catch (DbUpdateException ex)
    {
        if (ex.InnerException?.Message.Contains("IX_Assets_Serial_Number") == true)
        {
            TempData["DuplicateSerialError"] = "😿 Oops! This serial number already exists. Please check and try again.";
            return RedirectToPage(); // Stay on current page and show message
        }

        throw; // If it's a different error, rethrow
    }

}
}
}