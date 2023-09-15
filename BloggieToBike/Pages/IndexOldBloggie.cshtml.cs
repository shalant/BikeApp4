//using BloggieToBike.Web.Models.Domain;
//using BloggieToBike.Web.Repositories;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;

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