using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BloggieToBike.Models;
using BloggieToBike.Web.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            //original code from before search
            //if (_context.NewBikeRoute != null)
            //{
            //    NewBikeRoute = await _context.NewBikeRoute.ToListAsync();
            //}

            IQueryable<string> directionQuery = from b in _context.NewBikeRoute
                                                orderby b.Direction
                                                select b.Direction;

            var newBikeRoutes = from b in _context.NewBikeRoute
                                select b;

            if(!string.IsNullOrEmpty(SearchString))
            {
                newBikeRoutes = newBikeRoutes.Where(s => s.Name.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(RouteDirection))
            {
                newBikeRoutes = newBikeRoutes.Where(x => x.Direction == RouteDirection);
            }
            Directions = new SelectList(await directionQuery.Distinct().ToListAsync());
            NewBikeRoute = await newBikeRoutes.ToListAsync();
        }

        //USING the tutorial's search code, maybe I can understand how to search by length after
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Directions { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? RouteDirection { get; set; }
    }
}
