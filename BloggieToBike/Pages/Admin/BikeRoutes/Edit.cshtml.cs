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
//namespace BloggieToBike.Web.Pages.Admin.Routes
{
    //[Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly IBikeRouteRepository bikeRouteRepository;

        [BindProperty]
        public EditBikeRouteRequest BikeRoute { get; set; }

        //[BindProperty]
        //public IFormFile FeaturedImage { get; set; }

        [BindProperty]
        //[Required]
        public string Tags { get; set; }

        public EditModel(IBikeRouteRepository bikeRouteRepository)
        {
            this.bikeRouteRepository = bikeRouteRepository;
        }

        //public async Task OnGet(Guid id)
        public async Task OnGet(Guid id)
        {
            var bikerouteDomainModel = await bikeRouteRepository.GetAsync(id);

            if(bikerouteDomainModel != null && bikerouteDomainModel.Tags != null)
            {
                BikeRoute = new EditBikeRouteRequest
                {
                    Id = bikerouteDomainModel.Id,
                    Name = bikerouteDomainModel.Name,
                    Length = bikerouteDomainModel.Length,
                    Elevation = bikerouteDomainModel.Elevation,
                    Direction = bikerouteDomainModel.Direction,
                    Content = bikerouteDomainModel.Content,
                    ShortDescription = bikerouteDomainModel.ShortDescription,
                    FeaturedImageUrl = bikerouteDomainModel.FeaturedImageUrl,
                    StravaLink = bikerouteDomainModel.StravaLink,
                    PublishedDate = bikerouteDomainModel.PublishedDate,
                    Author = bikerouteDomainModel.Author,
                    Visible = bikerouteDomainModel.Visible,
                    //Comments = bikerouteDomainModel.Comments,
                    //Likes = bikerouteDomainModel.Likes,
                    //Tags = bikerouteDomainModel.Tags,
                };

                Tags = string.Join(',', bikerouteDomainModel.Tags.Select(x => x.Name));
            }
        }

        public async Task<IActionResult> OnRouteEdit()
        {
            ValidateEditBikeRoute();

            if (ModelState.IsValid)
            {
                try
                {
                    var bikeRouteDomainModel = new BikeRoute
                    {
                        Id = BikeRoute.Id,
                        Name = BikeRoute.Name,
                        Length = BikeRoute.Length,
                        Elevation = BikeRoute.Elevation,
                        Content = BikeRoute.Content,
                        ShortDescription = BikeRoute.ShortDescription,
                        FeaturedImageUrl = BikeRoute.FeaturedImageUrl,
                        StravaLink = BikeRoute.StravaLink,
                        PublishedDate = BikeRoute.PublishedDate,
                        Author = BikeRoute.Author,
                        Visible = BikeRoute.Visible,
                        //Likes = BikeRoute.Likes,
                        //Comments = BikeRoute.Comments,
                        Tags = new List<Tag>(Tags.Split(',').Select(x => new Tag() { Name = x.Trim() }))
                    };

                    await bikeRouteRepository.UpdateAsync(bikeRouteDomainModel);

                    ViewData["Notification"] = new Notification
                    {
                        Type = Enums.NotificationType.Success,
                        Message = "Record Updated successfully!"
                    };
                }
                catch (Exception ex)
                {
                    ViewData["Notification"] = new Notification
                    {
                        Type = Enums.NotificationType.Error,
                        Message = "Something went wrong!"
                    };
                }

                return Page();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostDelete()
        {
            var deleted = await bikeRouteRepository.DeleteAsync(BikeRoute.Id);
            if (deleted)
            {
                var notification = new Notification
                {
                    Type = Enums.NotificationType.Success,
                    Message = "Blog deleted successfully!"
                };

                TempData["Notification"] = JsonSerializer.Serialize(notification);

                return RedirectToPage("/Admin/Blogs/List");
            }

            return Page();
        }

        private void ValidateEditBikeRoute()
        {
            if (!string.IsNullOrWhiteSpace(BikeRoute.Name))
            {
                // check for minimum length
                if(BikeRoute.Name.Length < 10 || BikeRoute.Name.Length > 72)
                {
                    ModelState.AddModelError("BlogPost.Name",
                        "Heading can only be between 10 and 72 characters");
                }
                // check for maximum length
            }
        }
    }
}
