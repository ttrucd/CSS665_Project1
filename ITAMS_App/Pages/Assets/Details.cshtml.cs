using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ITAMS_App.Data;
using ITAMS_App.Models;

namespace ITAMS_App.Pages.Assets
{
    public class DetailsModel : PageModel
    {
        private readonly ITAMS_App.Data.ITAMSDbContext _context;

        public DetailsModel(ITAMS_App.Data.ITAMSDbContext context)
        {
            _context = context;
        }

        public Asset? Asset { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Assets == null)
            {
            return NotFound();
            }
        //fetch the asset from db using the id, inclusing the related AssetType
            Asset = await _context.Assets
                .Include(a => a.AssetType)  //include the AssetType so we can access Type_Name
                .FirstOrDefaultAsync(m => m.Asset_Id == id);    //Find the asset with the given id

        //if no asset was found, return NotFound
            if (Asset == null)
            {
                return NotFound();
            }

        //return the page with details
            return Page();
        }

    }
}
