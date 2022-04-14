using MediatR;
using NotificationManagement.Domain.Event;
using System.Threading;
using System.Threading.Tasks;

namespace NotificationManagement.Domain.EventHandlers
{
    public class SendNotificationEventHandler : INotificationHandler<SendEmailEvent>, INotificationHandler<SendSmsEvent>
    {
        public async Task Handle(SendEmailEvent notification, CancellationToken cancellationToken)
        {
            // Send Email
            await Task.CompletedTask;
        }

        public async Task Handle(SendSmsEvent notification, CancellationToken cancellationToken)
        {
            // Send Sms
            await Task.CompletedTask;
        }
    }
}
