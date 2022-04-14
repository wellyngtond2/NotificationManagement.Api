using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using NotificationManagement.Domain.Application.Requests.Notification;
using NotificationManagement.Domain.Domain.Interfaces.Repository;

namespace NotificationManagement.Domain.Application.Validation.Notification
{
    public class UpdateNotificationValidator : AbstractValidator<UpdateNotificationRequest>
    {
        private readonly INotificationTemplateRepository _notificationTemplateRepository;
        private readonly INotificationRepository _notificationRepository;
        private readonly IPersonRepository _personRepository;

        public UpdateNotificationValidator(INotificationTemplateRepository notificationTemplateRepository, INotificationRepository notificationRepository, IPersonRepository personRepository)
        {
            _notificationTemplateRepository = notificationTemplateRepository;
            _notificationRepository = notificationRepository;
            _personRepository = personRepository;

            RuleFor(req => req.Id)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0);

            RuleFor(req => req.Data.Title)
                .NotEmpty()
                .NotNull()
                .MaximumLength(128);

            RuleFor(req => req.Data.Content)
                .NotEmpty()
                .NotNull()
                .MaximumLength(256);

            RuleFor(req => req.Data.TemplateId)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0);


            RuleFor(req => req.Data.PersonId)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0);

            RuleFor(req => req)
                .CustomAsync(Exists);
        }

        private async Task Exists(UpdateNotificationRequest request, ValidationContext<UpdateNotificationRequest> validationContext, CancellationToken cancellation)
        {
            var notification = await _notificationRepository.GetByIdAsync(request.Id);

            if (notification is null)
            {
                validationContext.AddFailure(nameof(request.Id), "Notification doesn't exist.");
                return;
            }

            var notificationTemplate = await _notificationTemplateRepository.GetByIdAsync(request.Data.TemplateId);

            if (notificationTemplate is null)
            {
                validationContext.AddFailure(nameof(request.Data.TemplateId), "Notification Template doesn't exist.");
                return;
            }

            var person = await _personRepository.GetByIdAsync(request.Data.PersonId);

            if (person is null)
            {
                validationContext.AddFailure(nameof(request.Data.PersonId), "Person doesn't exist.");
                return;
            }
        }
    }
}
