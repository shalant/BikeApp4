namespace BloggieToBike.Web.Models.Domain
{
    public class Tag
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid BikeRouteId { get; set; }
    }
}
