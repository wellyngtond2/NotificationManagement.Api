using AutoMapper;
using MediatR;
using NotificationManagement.Domain.Application.Requests.Notification;
using NotificationManagement.Domain.Application.Responses.Base;
using NotificationManagement.Domain.Application.Responses.Notification;
using NotificationManagement.Domain.Domain.Interfaces.Repository;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NotificationManagement.Domain.Domain.Handlers.Notification
{
    public class GetNotificationHandler : IRequestHandler<GetNotificationRequest, OperationResponse<ICollection<NotificationResponse>>>
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IMapper _mapper;

        public GetNotificationHandler(INotificationRepository notificationRepository, IMapper mapper)
        {
            _notificationRepository = notificationRepository;
            _mapper = mapper;
        }
        public async Task<OperationResponse<ICollection<NotificationResponse>>> Handle(GetNotificationRequest request, CancellationToken cancellationToken)
        {
            var notificationsTemplate = await _notificationRepository.GetAllIncludeEntitiesAsync(request.Filter.RecordsPerPage, request.Filter.PageNumber);

            var response = _mapper.Map<ICollection<NotificationResponse>>(notificationsTemplate);

            return OperationResponse.SuccessPaged(response, request.Filter.PageNumber);
        }
    }
}
