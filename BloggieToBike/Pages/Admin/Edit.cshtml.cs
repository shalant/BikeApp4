using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BloggieToBike.Models;
using BloggieToBike.Web.Data;
using Microsoft.AspNetCore.Authorization;

namespace BloggieToBike.Pages.NewBikeRoutes
{
    [Authorize(Roles = "SuperAdmin")]
    public class EditModel : PageModel
    {
        private readonly BloggieToBikeDbContext _context;

        public EditModel(BloggieToBikeDbContext context)
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

            var newbikeroute =  await _context.NewBikeRoute.FirstOrDefaultAsync(m => m.Id == id);
            if (newbikeroute == null)
            {
                return NotFound();
            }
            NewBikeRoute = newbikeroute;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(NewBikeRoute).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NewBikeRouteExists(NewBikeRoute.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            //return RedirectToPage("./Index");
            return RedirectToPage("/NewBikeRoutes/Index");
        }

        private bool NewBikeRouteExists(int id)
        {
          return (_context.NewBikeRoute?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
