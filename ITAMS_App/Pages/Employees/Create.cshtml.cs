using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ITAMS_App.Data;
using ITAMS_App.Models;

namespace ITAMS_App.Pages.Employees // make sure this matches your folder name
{
    public class CreateModel : PageModel
    {
        private readonly ITAMSDbContext _context;

        public CreateModel(ITAMSDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Employee Employee { get; set; } = default!;

        public List<SelectListItem> RoleList { get; set; } = new();

        public List<SelectListItem> AssetList { get; set; } = new();

        public IActionResult OnGet()
        {
            AssetList = _context.Assets
                .Select(a => new SelectListItem
                {
                    Value = a.Asset_Id.ToString(),
                    Text = a.Asset_Name
                }).ToList();

            RoleList = new List<SelectListItem>
            {
                new SelectListItem { Value = "Admin", Text = "Admin" },
                new SelectListItem { Value = "Staff", Text = "Staff" },
                new SelectListItem { Value = "Student", Text = "Student" }
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                // Rebuild dropdowns in case of form errors
                AssetList = _context.Assets
                    .Select(a => new SelectListItem
                    {
                        Value = a.Asset_Id.ToString(),
                        Text = a.Asset_Name
                    }).ToList();

                RoleList = new List<SelectListItem>
                {
                    new SelectListItem { Value = "Admin", Text = "Admin" },
                    new SelectListItem { Value = "Staff", Text = "Staff" },
                    new SelectListItem { Value = "Student", Text = "Student" }
                };

                return Page();
            }

            _context.Employees.Add(Employee);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
