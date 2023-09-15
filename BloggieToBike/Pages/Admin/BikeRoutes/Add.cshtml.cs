using BloggieToBike.Web.Data;
using BloggieToBike.Web.Models.Domain;
using BloggieToBike.Web.Models.ViewModels;
using BloggieToBike.Web.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace BloggieToBike.Web.Pages.Admin.BikeRoutes
{
    //[Authorize(Roles = "Admin")]
    public class AddModel : PageModel
    {
        private readonly IBikeRouteRepository bikeRouteRepository;

        [BindProperty]
        public AddBikeRoute AddBikeRouteRequest { get; set; }

        //[BindProperty]
        //public IFormFile FeaturedImage { get; set; }

        [BindProperty]
        [Required]
        public string Tags { get; set; }

        public AddModel(IBikeRouteRepository bikeRouteRepository)
        {
            this.bikeRouteRepository = bikeRouteRepository;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            ValidateAddBikeRoute();

            if (ModelState.IsValid)
            {

                var bikeRoute = new BikeRoute()
                {
                    Name = AddBikeRouteRequest.Name,
                    Length = AddBikeRouteRequest.Length,
                    Elevation = AddBikeRouteRequest.Elevation,
                    Direction = AddBikeRouteRequest.Direction,
                    Content = AddBikeRouteRequest.Content,
                    ShortDescription = AddBikeRouteRequest.ShortDescription,
                    FeaturedImageUrl = AddBikeRouteRequest.FeaturedImageUrl,
                    StravaLink = AddBikeRouteRequest.StravaLink,
                    PublishedDate = AddBikeRouteRequest.PublishedDate,
                    Author = AddBikeRouteRequest.Author,
                    Visible = AddBikeRouteRequest.Visible,
                    Tags = new List<Tag>(Tags.Split(',').Select(x => new Tag() { Name = x.Trim() }))
                };

                await bikeRouteRepository.AddAsync(bikeRoute);

                var notification = new Notification
                {
                    Type = Enums.NotificationType.Success,
                    Message = "New bike route created!"
                };

                TempData["Notification"] = JsonSerializer.Serialize(notification);

                return RedirectToPage("/Admin/BikeRoutes/List");
            }

            return Page();
        }

        private void ValidateAddBikeRoute()
        {
            if(AddBikeRouteRequest.PublishedDate.Date < DateTime.Now.Date)
            {
                ModelState.AddModelError("AddBikeRouteRequest.PublishedDate",
                    $"Published Date can only be today's date or a future date.");
            }
        }
    }
}
