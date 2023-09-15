namespace BloggieToBike.Web.Models.Domain
{
    public class BikeRouteLike
    {
        public Guid Id { get; set; }
        public Guid BikeRouteId { get; set; }
        public Guid UserId { get; set; }
    }
}
