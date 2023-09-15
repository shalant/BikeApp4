using BloggieToBike.Web.Data;
using BloggieToBike.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BloggieToBike.Web.Repositories
{
    public class BikeRouteRepository : IBikeRouteRepository
    {
        private readonly BloggieToBikeDbContext bloggieToBikeDbContext;

        public BikeRouteRepository(BloggieToBikeDbContext bloggieToBikeDbContext)
        {
            this.bloggieToBikeDbContext = bloggieToBikeDbContext;
        }

        public async Task<BikeRoute> AddAsync(BikeRoute bikeRoute)
        {
            await bloggieToBikeDbContext.BikeRoutes.AddAsync(bikeRoute);
            await bloggieToBikeDbContext.SaveChangesAsync();
            return bikeRoute;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var existingBikeRoute = await bloggieToBikeDbContext.BikeRoutes.FindAsync(id);
            if(existingBikeRoute != null)
            {
                bloggieToBikeDbContext.BikeRoutes.Remove(existingBikeRoute);
                await bloggieToBikeDbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<IEnumerable<BikeRoute>> GetAllAsync()
        {
            return await bloggieToBikeDbContext.BikeRoutes.Include(nameof(BikeRoute.Tags)).ToListAsync();
        }

        public async Task<IEnumerable<BikeRoute>> GetAllAsync(string tagName)
        {
            return await (bloggieToBikeDbContext.BikeRoutes.Include(nameof(BikeRoute.Tags))
                .Where(x => x.Tags.Any(x => x.Name == tagName)))
                .ToListAsync();
        }

        public async Task<BikeRoute> GetAsync(Guid id)
        {
            return await bloggieToBikeDbContext.BikeRoutes.Include(nameof(BikeRoute.Tags))
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<BikeRoute> GetAsync(string stravaLink)
        {
            return await bloggieToBikeDbContext.BikeRoutes.Include(nameof(BikeRoute.Tags))
                .FirstOrDefaultAsync(x => x.StravaLink == stravaLink);
        }

        public async Task<BikeRoute> UpdateAsync(BikeRoute bikeRoute)
        {
            var existingBikeRoute = await bloggieToBikeDbContext.BikeRoutes.Include(nameof(BikeRoute.Tags))
                .FirstOrDefaultAsync(x => x.Id == bikeRoute.Id);

            if (existingBikeRoute != null)
            {
                existingBikeRoute.Name = bikeRoute.Name;
                existingBikeRoute.Length = bikeRoute.Length;
                existingBikeRoute.Elevation = bikeRoute.Elevation;
                existingBikeRoute.Direction = bikeRoute.Direction;
                existingBikeRoute.Content = bikeRoute.Content;
                existingBikeRoute.ShortDescription = bikeRoute.ShortDescription;
                existingBikeRoute.FeaturedImageUrl = bikeRoute.FeaturedImageUrl;
                existingBikeRoute.StravaLink = bikeRoute.StravaLink;
                existingBikeRoute.PublishedDate = bikeRoute.PublishedDate;
                existingBikeRoute.Author = bikeRoute.Author;
                existingBikeRoute.Visible = bikeRoute.Visible;

                //if(bikeRoute.Tags != null && bikeRoute.Tags.Any())
                //{
                //    // Delete the existing tags
                //    bloggieToBikeDbContext.Tags.RemoveRange(existingBikeRoute.Tags);

                //    // Add new tags
                //    bikeRoute.Tags.ToList().ForEach(x => x.BikeRouteId = existingBikeRoute.Id);
                //    await bloggieToBikeDbContext.Tags.AddRangeAsync(bikeRoute.Tags);
                //}
            }

            await bloggieToBikeDbContext.SaveChangesAsync();
            return existingBikeRoute;
        }
    }
}
