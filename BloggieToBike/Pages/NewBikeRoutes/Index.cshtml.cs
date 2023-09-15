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
    public class IndexModel : PageModel
    {
        private readonly BloggieToBikeDbContext _context;

        public IndexModel(BloggieToBikeDbContext context)
        {
            _context = context;
        }

        public IList<NewBikeRoute> NewBikeRoute { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.NewBikeRoute != null)
            {
                NewBikeRoute = await _context.NewBikeRoute.ToListAsync();
            }
        }
    }
}
