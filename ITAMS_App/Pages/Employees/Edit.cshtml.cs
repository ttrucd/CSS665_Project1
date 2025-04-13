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

namespace ITAMS_App.Pages_Employees
{
    public class EditModel : PageModel
    {
        private readonly ITAMSDbContext _context;

        public EditModel(ITAMSDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Employee Employee { get; set; } = default!;

        public SelectList AssetList { get; set; } = default!;
        public List<SelectListItem> RoleList { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.AssignedAsset)
                .FirstOrDefaultAsync(m => m.Employee_Id == id);

            if (employee == null)
            {
                return NotFound();
            }

            Employee = employee;

            // Populate dropdowns
            AssetList = new SelectList(_context.Assets, "Asset_Id", "Asset_Id");
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
                // Re-populate dropdowns if there's a validation error
                AssetList = new SelectList(_context.Assets, "Asset_Id", "Asset_Id");
                RoleList = new List<SelectListItem>
                {
                    new SelectListItem { Value = "Admin", Text = "Admin" },
                    new SelectListItem { Value = "Staff", Text = "Staff" },
                    new SelectListItem { Value = "Student", Text = "Student" }
                };
                return Page();
            }

            _context.Attach(Employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(Employee.Employee_Id))
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

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.Employee_Id == id);
        }
    }
}

