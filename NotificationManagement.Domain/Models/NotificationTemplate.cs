namespace NotificationManagement.Domain.Domain.Models
{
    public class NotificationTemplate : EntityBase
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int Type { get; set; }
    }
}
