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
        //List to hold the available permission option for the dropdown
        public List<SelectListItem> PermissionOptions { get; set; } = new();

        //GET method to load the page and populate the dropwdown
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

        //POST method to handle form submission and add the new Administrator
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                //If validation fails, repopulate the permission dropdown and stay on the page
                PermissionOptions = Enum.GetValues(typeof(AdminPermission))
                .Cast<AdminPermission>()
                .Select(p => new SelectListItem
                {
                Value = p.ToString(),
                Text = p.ToString()
                }).ToList();
                
                return Page();
            }
            //Add the new Administrator to the database
            _context.Administrators.Add(Administrator);
            await _context.SaveChangesAsync();

            //Redirect to the list of Administrator after create successful
            return RedirectToPage("./Index");
        }
    }
}
