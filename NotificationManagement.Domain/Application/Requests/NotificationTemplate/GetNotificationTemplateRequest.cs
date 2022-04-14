using MediatR;
using NotificationManagement.Domain.Application.Responses.NotificationTemplate;
using System.Collections.Generic;
using NotificationManagement.Domain.Application.Responses.Base;

namespace NotificationManagement.Domain.Application.Requests.NotificationTemplate
{
    public sealed class GetNotificationTemplateRequest : IRequest<OperationResponse<ICollection<NotificationTemplateResponse>>>
    {
        public GetNotificationTemplateFilterRequest Filter { get;  }

        public GetNotificationTemplateRequest(GetNotificationTemplateFilterRequest filter)
        {
            Filter = filter;
        }
    }
}
