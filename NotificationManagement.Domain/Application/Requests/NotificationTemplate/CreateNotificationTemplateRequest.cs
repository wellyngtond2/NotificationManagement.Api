using MediatR;
using NotificationManagement.Domain.Application.Responses.Base;

namespace NotificationManagement.Domain.Application.Requests.NotificationTemplate
{
    public sealed class CreateNotificationTemplateRequest : IRequest<OperationResponse>
    {
        public NotificationTemplateRequest Data { get; }

        public CreateNotificationTemplateRequest(NotificationTemplateRequest data)
        {
            Data = data;
        }
    }
}
