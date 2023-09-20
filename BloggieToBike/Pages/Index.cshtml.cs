using BloggieToBike.Models;
using BloggieToBike.Web.Data;
using BloggieToBike.Web.Models.Domain;
using BloggieToBike.Web.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BloggieToBike.Pages.IndexModel
{
    public class IndexModel : PageModel
    {
        private readonly BloggieToBikeDbContext _context;

        public IndexModel(BloggieToBikeDbContext context)
        {
            _context = context;
        }

        //DECIDER CODE
        [BindProperty(SupportsGet = true)]
        public int lengthInt { get; set; }

        public IList<NewBikeRoute> NewBikeRoute { get; set; } = default!;
        public IList<Event> Events { get; set; } = default!;

        public async Task OnGetAsync()
        {
            //OLD CODE THAT WORKS FINE
            if (_context.NewBikeRoute != null)
            {
                NewBikeRoute = await _context.NewBikeRoute.ToListAsync();
                Events = await _context.Events.ToListAsync();
            }

            //var newBikeRouteByLength = from b in _context.NewBikeRoute
            //                    select b;
            //if (String.IsNullOrEmpty(lengthInt.ToString()))
            //    {
            //    newBikeRouteByLength = newBikeRoutes.Where(l => l.Length.Equals(lengthInt));
            //}

            //NewBikeRoute = await newBikeRoutes.ToListAsync();

        }


        


    }
}

//old code
//namespace BloggieToBike.Web.Pages
//{
//    public class IndexModel : PageModel
//    {
//        private readonly ILogger<IndexModel> _logger;
//        private readonly IBikeRouteRepository bikeRouteRepository;
//        private readonly ITagRepository tagRepository;

//        public List<BikeRoute> Routes { get; set; }
//        public List<Tag> Tags { get; set; }

//        public IndexModel(ILogger<IndexModel> logger, 
//            IBikeRouteRepository bikeRouteRepository,
//            ITagRepository tagRepository)
//        {
//            _logger = logger;
//            this.bikeRouteRepository = bikeRouteRepository;
//            this.tagRepository = tagRepository;
//        }

//        public async Task<IActionResult> OnGet()
//        {
//            Routes = (await bikeRouteRepository.GetAllAsync()).ToList();
//            Tags = (await tagRepository.GetAllAsync()).ToList();
//            return Page();
//        }
//    }
//}