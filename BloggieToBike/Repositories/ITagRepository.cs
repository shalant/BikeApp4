using BloggieToBike.Web.Models.Domain;

namespace BloggieToBike.Web.Repositories
{
    public interface ITagRepository
    {
        Task<IEnumerable<Tag>> GetAllAsync();
    }
}
