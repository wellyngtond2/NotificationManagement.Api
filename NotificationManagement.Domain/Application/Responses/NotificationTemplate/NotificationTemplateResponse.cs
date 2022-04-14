using NotificationManagement.Domain.Shared.Enums;

namespace NotificationManagement.Domain.Application.Responses.NotificationTemplate
{
    public class NotificationTemplateResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public NotificationTemplateTypeEnum NotificationTemplateType { get; set; }
    }
}
