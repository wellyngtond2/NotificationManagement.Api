using AutoMapper;
using MediatR;
using NotificationManagement.Domain.Application.Requests.NotificationTemplate;
using NotificationManagement.Domain.Application.Responses.Base;
using NotificationManagement.Domain.Domain.Interfaces.Repository;
using System.Threading;
using System.Threading.Tasks;

namespace NotificationManagement.Domain.Domain.Handlers.NotificationTemplate
{
    public class UpdateNotificationTemplateHandler : IRequestHandler<UpdateNotificationTemplateRequest, OperationResponse>
    {
        private readonly INotificationTemplateRepository _notificationTemplateRepository;
        private readonly IMapper _mapper;

        public UpdateNotificationTemplateHandler(INotificationTemplateRepository notificationTemplateRepository, IMapper mapper)
        {
            _notificationTemplateRepository = notificationTemplateRepository;
            _mapper = mapper;
        }
        public async Task<OperationResponse> Handle(UpdateNotificationTemplateRequest request, CancellationToken cancellationToken)
        {
            var notificationTemplate = await _notificationTemplateRepository.GetByIdAsync(request.Id);
            notificationTemplate.Title = request.Data.Title;
            notificationTemplate.Content = request.Data.Content;
            notificationTemplate.Type = (int)request.Data.NotificationTemplateType;

            await _notificationTemplateRepository.UpdateAsync(notificationTemplate);

            return OperationResponse.Success();
        }
    }
}
