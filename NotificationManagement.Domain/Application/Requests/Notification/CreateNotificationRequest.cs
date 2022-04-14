using MediatR;
using NotificationManagement.Domain.Application.Responses.Base;

namespace NotificationManagement.Domain.Application.Requests.Notification
{
    public sealed class CreateNotificationRequest : IRequest<OperationResponse>
    {
        public NotificationRequest Data { get; }

        public CreateNotificationRequest(NotificationRequest data)
        {
            Data = data;
        }
    }
}
