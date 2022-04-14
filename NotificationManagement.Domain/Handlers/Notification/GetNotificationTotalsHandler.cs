using AutoMapper;
using MediatR;
using NotificationManagement.Domain.Application.Requests.Notification;
using NotificationManagement.Domain.Application.Responses.Base;
using NotificationManagement.Domain.Application.Responses.Notification;
using NotificationManagement.Domain.Domain.Interfaces.Repository;
using System.Threading;
using System.Threading.Tasks;

namespace NotificationManagement.Domain.Domain.Handlers.Notification
{
    public class GetNotificationTotalsHandler : IRequestHandler<GetNotificationTotalsRequest, OperationResponse<NotificationsTotalsResponse>>
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IMapper _mapper;

        public GetNotificationTotalsHandler(INotificationRepository notificationRepository, IMapper mapper)
        {
            _notificationRepository = notificationRepository;
            _mapper = mapper;
        }
        public async Task<OperationResponse<NotificationsTotalsResponse>> Handle(GetNotificationTotalsRequest request, CancellationToken cancellationToken)
        {
            var totals = await _notificationRepository.GetTotalsAsync();

            var response = _mapper.Map<NotificationsTotalsResponse>(totals);

            return OperationResponse.Success(response);
        }
    }
}
