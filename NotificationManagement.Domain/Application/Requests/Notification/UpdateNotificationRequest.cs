using MediatR;
using NotificationManagement.Domain.Application.Responses.Base;

namespace NotificationManagement.Domain.Application.Requests.Notification
{
    public sealed class UpdateNotificationRequest : IRequest<OperationResponse>
    {
        public int Id { get; }
        public NotificationRequest Data { get; }

        public UpdateNotificationRequest(int id, NotificationRequest data)
        {
            Id = id;
            Data = data;
        }
    }
}
