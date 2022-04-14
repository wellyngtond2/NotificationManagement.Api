using System.ComponentModel.DataAnnotations;
using NotificationManagement.Domain.Shared.Enums;

namespace NotificationManagement.Domain.Application.Requests.NotificationTemplate
{
    public class NotificationTemplateRequest
    {
        public string Title { get; set; }
        public string Content { get; set; }
        [Required]
        public NotificationTemplateTypeEnum NotificationTemplateType { get; set; }
    }
}
