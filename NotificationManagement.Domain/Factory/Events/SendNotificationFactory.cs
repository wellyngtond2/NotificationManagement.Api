using MediatR;
using NotificationManagement.Domain.Domain.Models;
using NotificationManagement.Domain.Event;
using NotificationManagement.Domain.Shared.Enums;

namespace NotificationManagement.Domain.Factory.Events
{
    public static class SendNotificationFactory
    {
        public static INotification GetNotification(Notification notification)
        {
            switch ((NotificationTemplateTypeEnum)notification.NotificationTemplate.Type)
            {
                case NotificationTemplateTypeEnum.Email: return new SendEmailEvent(notification);
                case NotificationTemplateTypeEnum.Sms: return new SendSmsEvent(notification);
                default: return new SendEmailEvent(notification);
            }
        }
    }
}
