using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ITAMS_App.Data;
using ITAMS_App.Models;

namespace ITAMS_App.Pages_Administrators
{
    public class DetailsModel : PageModel
    {
        private readonly ITAMS_App.Data.ITAMSDbContext _context;

        public DetailsModel(ITAMS_App.Data.ITAMSDbContext context)
        {
            _context = context;
        }

        public Administrator Administrator { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administrator = await _context.Administrators.FirstOrDefaultAsync(m => m.Admin_Id == id);

            if (administrator is not null)
            {
                Administrator = administrator;

                return Page();
            }

            return NotFound();
        }
    }
}
