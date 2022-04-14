namespace NotificationManagement.Domain.Domain.Models
{
    public class Notification : EntityBase
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int NotificationTemplateId { get; set; }
        public NotificationTemplate NotificationTemplate { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public bool WasSent { get; set; }

    }
}
