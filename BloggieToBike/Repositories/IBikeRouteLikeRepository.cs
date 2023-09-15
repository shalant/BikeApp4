using BloggieToBike.Web.Models.Domain;

namespace BloggieToBike.Web.Repositories
{
    public interface IBikeRouteLikeRepository
    {
        Task<int> GetTotalLikesForBikeRoute(Guid blogId);

        Task AddLikeForBikeRoute(Guid blogPostId, Guid userId);

        Task<IEnumerable<BikeRouteLike>> GetLikesForBikeRoute(Guid bikeRouteId);
    }
}
