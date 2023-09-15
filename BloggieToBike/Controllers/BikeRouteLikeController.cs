using BloggieToBike.Web.Models.ViewModels;
using BloggieToBike.Web.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BloggieToBike.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BikeRouteLikeController : Controller
    {
        //private readonly IBlogPostLikeRepository blogPostLikeRepository;
        private readonly IBikeRouteLikeRepository bikeRouteLikeRepository;

        //public BlogPostLikeController(IBlogPostLikeRepository blogPostLikeRepository)
        public BikeRouteLikeController(IBikeRouteLikeRepository bikeRouteLikeRepository)
        {
            this.bikeRouteLikeRepository = bikeRouteLikeRepository;
        }

        [Route("Add")]
        [HttpPost]
        public async Task<IActionResult> AddLike([FromBody] AddBikeRouteLikeRequest addBikeRouteLikeRequest)
        {
            await bikeRouteLikeRepository.AddLikeForBikeRoute(addBikeRouteLikeRequest.BikeRouteId,
                addBikeRouteLikeRequest.UserId);

            return Ok();
        }

        [HttpGet]
        [Route("{bikeRouteId:Guid}/totalLikes")]
        public async Task<IActionResult> GetTotalLikes([FromRoute] Guid bikeRouteId)
        {
            var totalLikes = await bikeRouteLikeRepository.GetTotalLikesForBikeRoute(bikeRouteId);

            return Ok(totalLikes);
        }
    }
}
