using NotificationManagement.Domain.Application.Requests.Base;

namespace NotificationManagement.Domain.Application.Requests.Notification
{
    public class GetNotificationFilterRequest : PaginationFilterRequest
    {
        public int? Id { get; set; }
    }
}
