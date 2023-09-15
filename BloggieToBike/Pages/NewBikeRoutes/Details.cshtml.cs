using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BloggieToBike.Models;
using BloggieToBike.Web.Data;

namespace BloggieToBike.Pages.NewBikeRoutes
{
    public class DetailsModel : PageModel
    {
        private readonly BloggieToBike.Web.Data.BloggieToBikeDbContext _context;

        public DetailsModel(BloggieToBike.Web.Data.BloggieToBikeDbContext context)
        {
            _context = context;
        }

      public NewBikeRoute NewBikeRoute { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.NewBikeRoute == null)
            {
                return NotFound();
            }

            var newbikeroute = await _context.NewBikeRoute.FirstOrDefaultAsync(m => m.Id == id);
            if (newbikeroute == null)
            {
                return NotFound();
            }
            else 
            {
                NewBikeRoute = newbikeroute;
            }
            return Page();
        }
    }
}
