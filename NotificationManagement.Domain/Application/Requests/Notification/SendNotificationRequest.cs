using MediatR;
using NotificationManagement.Domain.Application.Responses.Base;

namespace NotificationManagement.Domain.Application.Requests.Notification
{
    public sealed class SendNotificationRequest : IRequest<OperationResponse>
    {
    }
}
