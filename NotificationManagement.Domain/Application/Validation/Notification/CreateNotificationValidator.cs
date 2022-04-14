using FluentValidation;
using NotificationManagement.Domain.Application.Requests.Notification;
using NotificationManagement.Domain.Domain.Interfaces.Repository;
using System.Threading;
using System.Threading.Tasks;

namespace NotificationManagement.Domain.Application.Validation.Notification
{
    public class CreateNotificationValidator : AbstractValidator<CreateNotificationRequest>
    {
        private readonly INotificationTemplateRepository _notificationTemplateRepository;
        private readonly IPersonRepository _personRepository;
        public CreateNotificationValidator(INotificationTemplateRepository notificationTemplateRepository, IPersonRepository personRepository)
        {
            _notificationTemplateRepository = notificationTemplateRepository;
            _personRepository = personRepository;
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

        private async Task Exists(CreateNotificationRequest request, ValidationContext<CreateNotificationRequest> validationContext, CancellationToken cancellation)
        {
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
