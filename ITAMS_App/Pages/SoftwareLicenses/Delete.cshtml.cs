using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ITAMS_App.Data;
using ITAMS_App.Models;

namespace ITAMS_App.Pages_SoftwareLicenses
{
    public class DeleteModel : PageModel
    {
        private readonly ITAMS_App.Data.ITAMSDbContext _context;

        public DeleteModel(ITAMS_App.Data.ITAMSDbContext context)
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

            var softwarelicense = await _context.SoftwareLicense.FirstOrDefaultAsync(m => m.License_Id == id);

            if (softwarelicense is not null)
            {
                SoftwareLicense = softwarelicense;

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

            var softwarelicense = await _context.SoftwareLicense.FindAsync(id);
            if (softwarelicense != null)
            {
                SoftwareLicense = softwarelicense;
                _context.SoftwareLicense.Remove(SoftwareLicense);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
