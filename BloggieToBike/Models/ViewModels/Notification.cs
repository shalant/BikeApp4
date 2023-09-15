using BloggieToBike.Web.Enums;

namespace BloggieToBike.Web.Models.ViewModels
{
    public class Notification
    {
        public string Message { get; set; }

        public NotificationType Type { get; set; }
    }
}
