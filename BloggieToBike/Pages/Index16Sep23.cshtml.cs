using BloggieToBike.Models;
using BloggieToBike.Web.Data;
using BloggieToBike.Web.Models.Domain;
using BloggieToBike.Web.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

//namespace BloggieToBike.Pages.IndexModel
//{
//    public class IndexModel : PageModel
//    {
//        private readonly BloggieToBikeDbContext _context;

//        public IndexModel(BloggieToBikeDbContext context)
//        {
//            _context = context;
//        }

//        public IList<NewBikeRoute> NewBikeRoute { get; set; } = default!;
//        public IList<Event> Events { get; set; } = default!;

//        public async Task OnGetAsync()
//        {
//            if (_context.NewBikeRoute != null)
//            {
//                NewBikeRoute = await _context.NewBikeRoute.ToListAsync();
//                Events = await _context.Events.ToListAsync();
//            }
//        }
//    }
//}

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