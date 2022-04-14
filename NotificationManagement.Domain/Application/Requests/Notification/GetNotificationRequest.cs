using MediatR;
using NotificationManagement.Domain.Application.Responses.Base;
using NotificationManagement.Domain.Application.Responses.Notification;
using System.Collections.Generic;

namespace NotificationManagement.Domain.Application.Requests.Notification
{
    public sealed class GetNotificationRequest : IRequest<OperationResponse<ICollection<NotificationResponse>>>
    {
        public GetNotificationFilterRequest Filter { get; }

        public GetNotificationRequest(GetNotificationFilterRequest filter)
        {
            Filter = filter;
        }
    }
}
