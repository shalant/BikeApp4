using BloggieToBike.Web.Models.Domain;

namespace BloggieToBike.Web.Repositories
{
    public interface IBikeRouteRepository
    {
        Task<IEnumerable<BikeRoute>> GetAllAsync();
        Task<IEnumerable<BikeRoute>> GetAllAsync(string tagName);
        Task<BikeRoute> GetAsync(Guid id);
        Task<BikeRoute> GetAsync(string urlHandle);
        Task<BikeRoute> AddAsync(BikeRoute bikeRoute);
        Task<BikeRoute> UpdateAsync(BikeRoute bikeRoute);
        Task<bool> DeleteAsync(Guid id);
    }
}
