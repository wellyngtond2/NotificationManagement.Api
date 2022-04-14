using MediatR;
using NotificationManagement.Domain.Application.Responses.Base;
using NotificationManagement.Domain.Application.Responses.Notification;

namespace NotificationManagement.Domain.Application.Requests.Notification
{
    public sealed class GetNotificationTotalsRequest : IRequest<OperationResponse<NotificationsTotalsResponse>>
    {
    }
}
