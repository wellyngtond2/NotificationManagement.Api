using NotificationManagement.Domain.Application.Responses.Base;

namespace NotificationManagement.Domain.Application.Responses.Notification
{
    public class NotificationResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public IdentityResponse NotificationTemplate { get; set; }
        public IdentityResponse Person { get; set; }
        public bool WasSent { get; set; }
    }
}
