using BloggieToBike.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;
using BloggieToBike.Models;
using CloudinaryDotNet;

namespace BloggieToBike.Web.Data
{
    public class BloggieToBikeDbContext : DbContext
    {
        public BloggieToBikeDbContext(DbContextOptions<BloggieToBikeDbContext> options) : base(options)
        {
        }

        public DbSet<BikeRoute> BikeRoutes { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<BikeRouteLike> BikeRouteLikes { get; set; }
        public DbSet<BikeRouteComment> BikeRouteComments { get; set; }
        public DbSet<NewBikeRoute> NewBikeRoute { get; set; } = default!;
        public DbSet<Event> Events { get; set; }

        //Comparing to Contoso-------An Event is an "enrollment"-------A NewBikeRoute is a "course"
        //Each route/course can have multiple events/enrollments
        //OOOORRRR
        //A Blog is a bike route and a post is an event
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NewBikeRoute>()
                .HasMany(e => e.Events)
                .WithOne(e => e.NewBikeRoute)
                .HasForeignKey(e => e.NewBikeRouteId)
                .HasPrincipalKey(e => e.Id);
        }
    }
}
