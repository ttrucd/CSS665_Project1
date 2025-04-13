using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ITAMS_App.Data;
using ITAMS_App.Models;

namespace ITAMS_App.Pages_SoftwareLicenses
{
    public class CreateModel : PageModel
    {
        private readonly ITAMS_App.Data.ITAMSDbContext _context;

        public CreateModel(ITAMS_App.Data.ITAMSDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["Assigned_Employee_Id"] = new SelectList(_context.Employees, "Employee_Id", "Employee_Id");
            return Page();
        }

        [BindProperty]
        public SoftwareLicense SoftwareLicense { get; set; } = default!;

        
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.SoftwareLicense.Add(SoftwareLicense);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
