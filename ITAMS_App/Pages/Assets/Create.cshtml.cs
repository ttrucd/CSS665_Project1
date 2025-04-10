using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ITAMS_App.Data;
using ITAMS_App.Models;

namespace ITAMS_App.Pages.Assets
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
            return Page(); //Display the form 
        }

        [BindProperty]
        public Asset Asset { get; set; } = default!; // Asset to be created

        
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page(); // If the form is invalid, redisplay the page with validation errors
            }
            //Add the new asset to the context and save changes
            _context.Assets.Add(Asset);
            await _context.SaveChangesAsync();
            //Redirect to the Index page (list of assets) after successful creation
            return RedirectToPage("./Index");
        }
    }
}
