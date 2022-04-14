using NotificationManagement.Domain.Application.Requests.Base;

namespace NotificationManagement.Domain.Application.Requests.NotificationTemplate
{
    public class GetNotificationTemplateFilterRequest : PaginationFilterRequest
    {
        public int? Id { get; set; }

    }
}
