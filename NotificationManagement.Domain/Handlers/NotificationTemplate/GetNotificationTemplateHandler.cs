using AutoMapper;
using MediatR;
using NotificationManagement.Domain.Application.Requests.NotificationTemplate;
using NotificationManagement.Domain.Application.Responses.Base;
using NotificationManagement.Domain.Application.Responses.NotificationTemplate;
using NotificationManagement.Domain.Domain.Interfaces.Repository;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NotificationManagement.Domain.Domain.Handlers.NotificationTemplate
{
    public class GetNotificationTemplateHandler : IRequestHandler<GetNotificationTemplateRequest, OperationResponse<ICollection<NotificationTemplateResponse>>>
    {
        private readonly INotificationTemplateRepository _notificationTemplateRepository;
        private readonly IMapper _mapper;
        public GetNotificationTemplateHandler(INotificationTemplateRepository notificationTemplateRepository, IMapper mapper)
        {
            _notificationTemplateRepository = notificationTemplateRepository;
            _mapper = mapper;
        }
        public async Task<OperationResponse<ICollection<NotificationTemplateResponse>>> Handle(GetNotificationTemplateRequest request, CancellationToken cancellationToken)
        {
            var notificationsTemplate = await _notificationTemplateRepository.GetAllAsync(request.Filter.RecordsPerPage, request.Filter.PageNumber);

            var response = _mapper.Map<ICollection<NotificationTemplateResponse>>(notificationsTemplate);

            return OperationResponse.SuccessPaged(response, (request.Filter.PageNumber ?? 1));
        }
    }
}
