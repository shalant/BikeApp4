namespace BloggieToBike.Web.Models.Domain
{
    public class BikeRoute
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Length { get; set; }
        public int Elevation { get; set; }
        public string Direction { get; set; }
        public string Content { get; set; }
        public string ShortDescription { get; set; }
        public string FeaturedImageUrl { get; set; }
        public string StravaLink { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Author { get; set; }
        public bool Visible { get; set; }

        // Navigation Property
        public ICollection<Tag> Tags { get; set; }
        public ICollection<BikeRouteLike> Likes { get; set; }
        public ICollection<BikeRouteComment> Comments { get; set; }
    }
}
