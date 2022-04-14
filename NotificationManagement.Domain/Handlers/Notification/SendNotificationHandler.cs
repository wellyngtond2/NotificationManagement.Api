using AutoMapper;
using MediatR;
using NotificationManagement.Domain.Application.Requests.Notification;
using NotificationManagement.Domain.Application.Responses.Base;
using NotificationManagement.Domain.Domain.Interfaces.Repository;
using System;
using System.Threading;
using System.Threading.Tasks;
using NotificationManagement.Domain.Factory.Events;

namespace NotificationManagement.Domain.Domain.Handlers.Notification
{
    public class SendNotificationHandler : IRequestHandler<SendNotificationRequest, OperationResponse>
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IMediator _mediator;

        public SendNotificationHandler(INotificationRepository notificationRepository,IMediator mediator)
        {
            _notificationRepository = notificationRepository;
            _mediator = mediator;
        }
        public async Task<OperationResponse> Handle(SendNotificationRequest request, CancellationToken cancellationToken)
        {
            var notifications = await _notificationRepository.GetUnSentAsync();

            foreach (var notification in notifications)
            {
                var notificationEvent = SendNotificationFactory.GetNotification(notification);

                await _mediator.Publish(notificationEvent, cancellationToken);

                await _notificationRepository.SetAsSentAsync(notification);

            }

            return OperationResponse.Success();
        }
    }
}
