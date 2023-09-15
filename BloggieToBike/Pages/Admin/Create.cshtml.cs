using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BloggieToBike.Models;
using BloggieToBike.Web.Data;
using Microsoft.AspNetCore.Authorization;

namespace BloggieToBike.Pages.NewBikeRoutes
{
    [Authorize(Roles = "SuperAdmin")]
    public class CreateModel : PageModel
    {
        private readonly BloggieToBikeDbContext _context;

        public CreateModel(BloggieToBikeDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public NewBikeRoute NewBikeRoute { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.NewBikeRoute == null || NewBikeRoute == null)
            {
                return Page();
            }

            _context.NewBikeRoute.Add(NewBikeRoute);
            await _context.SaveChangesAsync();

            return RedirectToPage("/NewBikeRoutes/Index");
        }
    }
}
