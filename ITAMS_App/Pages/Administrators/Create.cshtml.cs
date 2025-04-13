using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ITAMS_App.Data;
using ITAMS_App.Models;

namespace ITAMS_App.Pages_Administrators
{
    public class CreateModel : PageModel
    {
        private readonly ITAMS_App.Data.ITAMSDbContext _context;

        public CreateModel(ITAMS_App.Data.ITAMSDbContext context)
        {
            _context = context;
        }
        public List<SelectListItem> PermissionOptions { get; set; } = new();

        public IActionResult OnGet()
        {
            PermissionOptions = Enum.GetValues(typeof(AdminPermission))
                .Cast<AdminPermission>()
                .Select(p => new SelectListItem
                {
                Value = p.ToString(),
                Text = p.ToString()
                }).ToList();

            return Page();
        }

        [BindProperty]
        public Administrator Administrator { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                PermissionOptions = Enum.GetValues(typeof(AdminPermission))
                .Cast<AdminPermission>()
                .Select(p => new SelectListItem
                {
                Value = p.ToString(),
                Text = p.ToString()
                }).ToList();
                
                return Page();
            }

            _context.Administrators.Add(Administrator);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
