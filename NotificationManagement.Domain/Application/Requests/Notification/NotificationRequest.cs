using System.ComponentModel.DataAnnotations;

namespace NotificationManagement.Domain.Application.Requests.Notification
{
    public class NotificationRequest
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int TemplateId { get; set; }
        public int PersonId { get; set; }
    }
}
