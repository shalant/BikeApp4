using BloggieToBike.Web.Models.Domain;
using BloggieToBike.Web.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BloggieToBike.Web.Pages.Tags
{
    public class DetailsModel : PageModel
    {
        private readonly IBikeRouteRepository bikeRouteRepository;

        public List<BikeRoute> Routes { get; set; }

        public DetailsModel(IBikeRouteRepository bikeRouteRepository)
        {
            this.bikeRouteRepository = bikeRouteRepository;
        }

        public async Task<IActionResult> OnGet(string tagName)
        {
            Routes = (await bikeRouteRepository.GetAllAsync(tagName)).ToList();
            return Page();
        }
    }
}
