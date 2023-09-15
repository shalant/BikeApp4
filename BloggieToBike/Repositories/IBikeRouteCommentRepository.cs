using BloggieToBike.Web.Models.Domain;

namespace BloggieToBike.Web.Repositories
{
    public interface IBikeRouteCommentRepository
    {
        Task<BikeRouteComment> AddAsync(BikeRouteComment bikeRouteComment);

        Task<IEnumerable<BikeRouteComment>> GetAllAsync(Guid bikeRouteId);
    }
}
