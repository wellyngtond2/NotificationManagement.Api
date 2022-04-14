using AutoMapper;
using MediatR;
using NotificationManagement.Domain.Application.Requests.Notification;
using NotificationManagement.Domain.Application.Responses.Base;
using NotificationManagement.Domain.Domain.Interfaces.Repository;
using System.Threading;
using System.Threading.Tasks;

namespace NotificationManagement.Domain.Domain.Handlers.Notification
{
    public class UpdateNotificationHandler : IRequestHandler<UpdateNotificationRequest, OperationResponse>
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IMapper _mapper;

        public UpdateNotificationHandler(INotificationRepository notificationRepository, IMapper mapper)
        {
            _notificationRepository = notificationRepository;
            _mapper = mapper;
        }
        public async Task<OperationResponse> Handle(UpdateNotificationRequest request, CancellationToken cancellationToken)
        {
            var notification = await _notificationRepository.GetByIdAsync(request.Id);
            notification.Title = request.Data.Title;
            notification.Content = request.Data.Content;
            notification.PersonId = request.Data.PersonId;
            notification.NotificationTemplateId = request.Data.TemplateId;

            await _notificationRepository.UpdateAsync(notification);

            return OperationResponse.Success();
        }
    }
}
