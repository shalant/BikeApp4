namespace BloggieToBike.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime EventDate { get; set; }

        public int NewBikeRouteId { get; set; }
        public NewBikeRoute? NewBikeRoute { get; set; }
    }
}
