using BloggieToBike.Web.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace BloggieToBike.Web.Models.ViewModels
{
    public class EditBikeRouteRequest
    {
        //[Required]
        public Guid Id { get; set; }

        //[Required]
        public string Name { get; set; }

        //[Required]
        public int Length { get; set; }

        //[Required]
        public int Elevation { get; set; }

        //[Required]
        public string Direction { get; set; }
        
        //[Required]
        public string Content { get; set; }
        
        //[Required]
        public string ShortDescription { get; set; }

        //[Required]
        public string FeaturedImageUrl { get; set; }

        //[Required]
        public string StravaLink { get; set; }

        //[Required]
        public DateTime PublishedDate { get; set; }

        //[Required]
        public string Author { get; set; }

        public bool Visible { get; set; }

        // Navigation Property
        public ICollection<Tag>? Tags { get; set; }
        public ICollection<BikeRouteLike>? Likes { get; set; }
        public ICollection<BikeRouteComment>? Comments { get; set; }

    }
}
