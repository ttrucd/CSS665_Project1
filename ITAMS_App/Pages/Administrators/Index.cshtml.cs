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
    public class IndexModel : PageModel
    {
        private readonly ITAMS_App.Data.ITAMSDbContext _context;

        public IndexModel(ITAMS_App.Data.ITAMSDbContext context)
        {
            _context = context;
        }

        public IList<Administrator> Administrator { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Administrator = await _context.Administrators.ToListAsync();
        }
    }
}
