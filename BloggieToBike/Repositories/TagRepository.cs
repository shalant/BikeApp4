using BloggieToBike.Web.Data;
using BloggieToBike.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BloggieToBike.Web.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly BloggieToBikeDbContext bloggieToBikeDbContext;

        public TagRepository(BloggieToBikeDbContext bloggieToBikeDbContext)
        {
            this.bloggieToBikeDbContext = bloggieToBikeDbContext;
        }


        public async Task<IEnumerable<Tag>> GetAllAsync()
        {
            var tags = await bloggieToBikeDbContext.Tags.ToListAsync();

            return tags.DistinctBy(x => x.Name.ToLower());


        }
    }
}
