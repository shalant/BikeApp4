using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BloggieToBike.Models;
using BloggieToBike.Web.Data;
using Microsoft.AspNetCore.Authorization;

namespace BloggieToBike.Pages.NewBikeRoutes
{
    [Authorize(Roles = "SuperAdmin")]
    public class DeleteModel : PageModel
    {
        private readonly BloggieToBike.Web.Data.BloggieToBikeDbContext _context;

        public DeleteModel(BloggieToBike.Web.Data.BloggieToBikeDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.NewBikeRoute == null)
            {
                return NotFound();
            }
            var newbikeroute = await _context.NewBikeRoute.FindAsync(id);

            if (newbikeroute != null)
            {
                NewBikeRoute = newbikeroute;
                _context.NewBikeRoute.Remove(NewBikeRoute);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("/NewBikeRoutes/Index");
        }
    }
}
