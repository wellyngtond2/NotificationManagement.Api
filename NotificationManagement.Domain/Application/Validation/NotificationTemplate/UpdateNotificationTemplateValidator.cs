using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using NotificationManagement.Domain.Application.Requests.NotificationTemplate;
using NotificationManagement.Domain.Domain.Interfaces.Repository;

namespace NotificationManagement.Domain.Application.Validation.NotificationTemplate
{
    public class UpdateNotificationTemplateValidator : AbstractValidator<UpdateNotificationTemplateRequest>
    {
        private readonly INotificationTemplateRepository _repository;
        public UpdateNotificationTemplateValidator(INotificationTemplateRepository repository)
        {
            _repository = repository;

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

            RuleFor(req => req)
                .CustomAsync(Exists);
        }

        private async Task Exists(UpdateNotificationTemplateRequest request, ValidationContext<UpdateNotificationTemplateRequest> validationContext, CancellationToken cancellation)
        {
            var notificationTemplate = await _repository.GetByIdAsync(request.Id);

            if (notificationTemplate is null)
            {
                validationContext.AddFailure(nameof(request.Id), "Notification Template doesn't exist.");
                return;
            }
        }
    }
}
