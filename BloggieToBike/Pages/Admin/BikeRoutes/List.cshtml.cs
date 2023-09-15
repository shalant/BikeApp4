using BloggieToBike.Web.Data;
using Bloggie.Web.Models.Domain;
using BloggieToBike.Web.Models.ViewModels;
using BloggieToBike.Web.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using BloggieToBike.Web.Models.Domain;

namespace BloggieToBike.Web.Pages.Admin.Routes
{
    //[Authorize(Roles = "Admin")]
    public class ListModel : PageModel
    {
        private readonly IBikeRouteRepository bikeRouteRepository;

        //public List<BikeRoute> BikeRoutes { get; set; }

        public List<BikeRoute> BikeRoutes { get; set; }

        public ListModel(IBikeRouteRepository bikeRouteRepository)
        {
            this.bikeRouteRepository = bikeRouteRepository;
        }

        public async Task OnGet()
        {
            var notificationJson = (string)TempData["Notification"];
            if(notificationJson != null)
            {
                ViewData["Notification"] = JsonSerializer.Deserialize<Notification>(notificationJson);
            }

            BikeRoutes = (await bikeRouteRepository.GetAllAsync())?.ToList();
        }
    }
}
