using ITAMS_App.Data;
using ITAMS_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ITAMS_App.Pages.Employees
{
    public class CreateModel : PageModel
    {
        private readonly ITAMSDbContext _context;

        public CreateModel(ITAMSDbContext context)
        {
            _context = context;
            Employee = new Employee
            {
                FirstName = "",
                LastName = "",
                Email = "",
                Department = "",
                Role = ""
            };
            AssetList = new List<SelectListItem>();
            RoleList = new List<SelectListItem>
            {
                new SelectListItem("Admin", "Admin"),
                new SelectListItem("Staff", "Staff"),
                new SelectListItem("Student", "Student")
            };
        }

        [BindProperty]
        public Employee Employee { get; set; }

        public List<SelectListItem> AssetList { get; set; }
        public List<SelectListItem> RoleList { get; set; }

        public async Task OnGetAsync()
        {
            AssetList = await _context.Assets
                .Select(a => new SelectListItem
                {
                    Value = a.Asset_Id.ToString(),
                    Text = a.Asset_Name
                }).ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await OnGetAsync(); // re-populate lists
                return Page();
            }

            _context.Employees.Add(Employee);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

