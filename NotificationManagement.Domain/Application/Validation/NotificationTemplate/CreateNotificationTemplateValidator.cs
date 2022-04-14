using FluentValidation;
using NotificationManagement.Domain.Application.Requests.NotificationTemplate;

namespace NotificationManagement.Domain.Application.Validation.NotificationTemplate
{
    public class CreateNotificationTemplateValidator : AbstractValidator<CreateNotificationTemplateRequest>
    {
        public CreateNotificationTemplateValidator()
        {
            RuleFor(req => req.Data.Title)
                .NotEmpty()
                .NotNull()
                .MaximumLength(128);

            RuleFor(req => req.Data.Content)
                .NotEmpty()
                .NotNull()
                .MaximumLength(256);
        }
    }
}
