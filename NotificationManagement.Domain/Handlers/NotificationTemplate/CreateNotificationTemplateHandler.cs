using System;
using AutoMapper;
using MediatR;
using NotificationManagement.Domain.Application.Requests.NotificationTemplate;
using NotificationManagement.Domain.Application.Responses.Base;
using NotificationManagement.Domain.Domain.Interfaces.Repository;
using System.Threading;
using System.Threading.Tasks;

namespace NotificationManagement.Domain.Domain.Handlers.NotificationTemplate
{
    public class CreateNotificationTemplateHandler : IRequestHandler<CreateNotificationTemplateRequest, OperationResponse>
    {
        private readonly INotificationTemplateRepository _notificationTemplateRepository;
        private readonly IMapper _mapper;

        public CreateNotificationTemplateHandler(INotificationTemplateRepository notificationTemplateRepository, IMapper mapper)
        {
            _notificationTemplateRepository = notificationTemplateRepository;
            _mapper = mapper;
        }
        public async Task<OperationResponse> Handle(CreateNotificationTemplateRequest request, CancellationToken cancellationToken)
        {
            var notificationTemplate = _mapper.Map<Models.NotificationTemplate>(request.Data);
            notificationTemplate.CreateDate = DateTime.Now;

            await _notificationTemplateRepository.CreateAsync(notificationTemplate);

            return OperationResponse.Success();
        }
    }
}
