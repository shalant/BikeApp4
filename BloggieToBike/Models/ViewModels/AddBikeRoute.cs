using System.ComponentModel.DataAnnotations;

namespace BloggieToBike.Web.Models.ViewModels
{
    public class AddBikeRoute
    {
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
    }
}
