using BloggieToBike.Web.Models.Domain;
using BloggieToBike.Web.Models.ViewModels;
using BloggieToBike.Web.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace BloggieToBike.Web.Pages.Route
{
    public class DetailsModel : PageModel
    {
        private readonly IBikeRouteRepository bikeRouteRepository;
        private readonly IBikeRouteLikeRepository bikeRouteLikeRepository;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IBikeRouteCommentRepository bikeRouteCommentRepository;

        public BikeRoute BikeRoute { get; set; }

        public List<RouteComment> Comments { get; set; }

        public int TotalLikes { get; set; }

        public bool Liked { get; set; }

        [BindProperty]
        public Guid BikeRouteId { get; set; }

        [BindProperty]
        [Required]
        [MinLength(1)]
        [MaxLength(200)]
        public string CommentDescription { get; set; }

        public DetailsModel(IBikeRouteRepository bikeRouteRepository,
            IBikeRouteLikeRepository bikeRouteLikeRepository,
            SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager,
            IBikeRouteCommentRepository bikeRouteCommentRepository)
        {
            this.bikeRouteRepository = bikeRouteRepository;
            this.bikeRouteLikeRepository = bikeRouteLikeRepository;
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.bikeRouteCommentRepository = bikeRouteCommentRepository;
        }

        public async Task<IActionResult> OnGet(string urlHandle)
        {
            await GetBlog(urlHandle);

            return Page();
        }

        public async Task<IActionResult> OnPost(string urlHandle)
        {
            if (ModelState.IsValid)
            {
                if (signInManager.IsSignedIn(User) && !string.IsNullOrWhiteSpace(CommentDescription))
                {
                    var userId = userManager.GetUserId(User);

                    var comment = new Models.Domain.BikeRouteComment
                    {
                        BikeRouteId = BikeRouteId,
                        Description = CommentDescription,
                        DateAdded = DateTime.Now,
                        UserId = Guid.Parse(userId)
                    };

                    await bikeRouteCommentRepository.AddAsync(comment);
                }

                return RedirectToPage("/Blog/Details", new { urlHandle = urlHandle });
            }

            await GetBlog(urlHandle);

            return Page();
        }

        private async Task GetComments()
        {
            var bikeRouteComments = await bikeRouteCommentRepository.GetAllAsync(BikeRoute.Id);

            var routeCommentsViewModel = new List<RouteComment>();
            foreach (var bikeRouteComment in bikeRouteComments)
            {
                routeCommentsViewModel.Add(new RouteComment
                {
                    DateAdded = bikeRouteComment.DateAdded,
                    Description = bikeRouteComment.Description,
                    //Username = (await userManager.FindByIdAsync(blogPostComment.UserId.ToString())).UserName
                });
            }

            Comments = routeCommentsViewModel;
        }

        private async Task GetBlog(string urlHandle)
        {
            BikeRoute = await bikeRouteRepository.GetAsync(urlHandle);

            if (BikeRoute != null)
            {
                BikeRouteId = BikeRoute.Id;
                if (signInManager.IsSignedIn(User))
                {
                    var likes = await bikeRouteLikeRepository.GetLikesForBikeRoute(BikeRoute.Id);

                    var userId = userManager.GetUserId(User);

                    Liked = likes.Any(x => x.UserId == Guid.Parse(userId));

                    await GetComments();
                }

                TotalLikes = await bikeRouteLikeRepository.GetTotalLikesForBikeRoute(BikeRoute.Id);
            }
        }
    }

}
