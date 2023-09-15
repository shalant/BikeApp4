using BloggieToBike.Web.Data;
using BloggieToBike.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BloggieToBike.Web.Repositories
{
    public class BikeRouteCommentRepository : IBikeRouteCommentRepository
    {
        private readonly BloggieToBikeDbContext bloggieToBikeDbContext;

        public BikeRouteCommentRepository(BloggieToBikeDbContext bloggieToBikeDbContext)
        {
            this.bloggieToBikeDbContext = bloggieToBikeDbContext;
        }

        public async Task<BikeRouteComment> AddAsync(BikeRouteComment bikeRouteComment)
        {
            await bloggieToBikeDbContext.BikeRouteComments.AddAsync(bikeRouteComment);
            await bloggieToBikeDbContext.SaveChangesAsync();
            return bikeRouteComment;
        }

        public async Task<IEnumerable<BikeRouteComment>> GetAllAsync(Guid bikeRouteId)
        {
            return await bloggieToBikeDbContext.BikeRouteComments.Where(x => x.BikeRouteId == bikeRouteId).ToListAsync();
        }
    }
}
