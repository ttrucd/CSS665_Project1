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

namespace ITAMS_App.Pages_Administrators
{
    public class EditModel : PageModel
    {
        private readonly ITAMS_App.Data.ITAMSDbContext _context;

        public EditModel(ITAMS_App.Data.ITAMSDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Administrator Administrator { get; set; } = default!;

        public List<SelectListItem> PermissionOptions { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administrator =  await _context.Administrators.FirstOrDefaultAsync(m => m.Admin_Id == id);
            if (administrator == null)
            {
                return NotFound();
            }
            Administrator = administrator;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        
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

            _context.Attach(Administrator).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdministratorExists(Administrator.Admin_Id))
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

        private bool AdministratorExists(int id)
        {
            return _context.Administrators.Any(e => e.Admin_Id == id);
        }
    }
}
