using MediatR;
using NotificationManagement.Domain.Application.Responses.Base;

namespace NotificationManagement.Domain.Application.Requests.NotificationTemplate
{
    public sealed class UpdateNotificationTemplateRequest : IRequest<OperationResponse>
    {
        public int Id { get; }
        public NotificationTemplateRequest Data { get; }

        public UpdateNotificationTemplateRequest(int id, NotificationTemplateRequest data)
        {
            Id = id;
            Data = data;
        }
    }
}