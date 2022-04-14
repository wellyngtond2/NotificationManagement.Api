using MediatR;
using NotificationManagement.Domain.Domain.Models;

namespace NotificationManagement.Domain.Event
{
    public class SendEmailEvent : INotification
    {
        public Notification Notification { get; }

        public SendEmailEvent(Notification notification)
        {
            Notification = notification;
        }
    }
}
