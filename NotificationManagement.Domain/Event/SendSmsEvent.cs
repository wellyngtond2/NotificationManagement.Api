using MediatR;
using NotificationManagement.Domain.Domain.Models;

namespace NotificationManagement.Domain.Event
{
    public class SendSmsEvent : INotification
    {
        public Notification Notification { get; }

        public SendSmsEvent(Notification notification)
        {
            this.Notification = notification;
        }
    }
}
