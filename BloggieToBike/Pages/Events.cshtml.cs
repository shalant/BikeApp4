using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BloggieToBike.Models;
using BloggieToBike.Web.Data;

namespace BloggieToBike.Pages.NewBikeRoutes
{
    public class EventsModel : PageModel
    {
        private readonly BloggieToBikeDbContext _context;

        public EventsModel(BloggieToBikeDbContext context)
        {
            _context = context;
        }

        public IList<Event> Event { get; set; } = default!;
        public IList<NewBikeRoute> NewBikeRoute { get; set; } = default;

        public async Task OnGetAsync()
        {
            if (_context.Events != null)
            {
                Event = await _context.Events.ToListAsync();
                NewBikeRoute = await _context.NewBikeRoute.ToListAsync();
            }
        }
    }
}
