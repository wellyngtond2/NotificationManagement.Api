using MediatR;
using NotificationManagement.Domain.Application.Requests.Notification;
using NotificationManagement.Domain.Application.Responses.Base;
using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using NotificationManagement.Domain.Domain.Interfaces.Repository;

namespace NotificationManagement.Domain.Domain.Handlers.Notification
{
    public class CreateNotificationHandler : IRequestHandler<CreateNotificationRequest, OperationResponse>
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IMapper _mapper;

        public CreateNotificationHandler(INotificationRepository notificationRepository, IMapper mapper)
        {
            _notificationRepository = notificationRepository;
            _mapper = mapper;
        }
        public async Task<OperationResponse> Handle(CreateNotificationRequest request, CancellationToken cancellationToken)
        {
            var notification = _mapper.Map<Models.Notification>(request.Data);
            notification.CreateDate = DateTime.Now;

            await _notificationRepository.CreateAsync(notification);

            return OperationResponse.Success();
        }
    }
}
