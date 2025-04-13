using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ITAMS_App.Data;
using ITAMS_App.Models;

namespace ITAMS_App.Pages_SoftwareLicenses
{
    public class EditModel : PageModel
    {
        private readonly ITAMS_App.Data.ITAMSDbContext _context;

        public EditModel(ITAMS_App.Data.ITAMSDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SoftwareLicense SoftwareLicense { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var softwarelicense =  await _context.SoftwareLicense.FirstOrDefaultAsync(m => m.License_Id == id);
            if (softwarelicense == null)
            {
                return NotFound();
            }
            SoftwareLicense = softwarelicense;
           ViewData["Assigned_Employee_Id"] = new SelectList(_context.Employees, "Employee_Id", "Employee_Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(SoftwareLicense).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SoftwareLicenseExists(SoftwareLicense.License_Id))
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

        private bool SoftwareLicenseExists(int id)
        {
            return _context.SoftwareLicense.Any(e => e.License_Id == id);
        }
    }
}
