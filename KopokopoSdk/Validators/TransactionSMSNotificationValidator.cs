using FluentValidation;
using KopokopoSdk.Requests;

namespace KopokopoSdk.Validators
{
    public class TransactionSMSNotificationValidator : AbstractValidator<TransactionSMSNotificationRequest>
    {
        public TransactionSMSNotificationValidator()
        {
            RuleFor(x => x.WebhookEventReference)
               .NotNull()
               .WithMessage("{PropertyName} - Webhook event reference is required.")
               .NotEmpty()
               .WithMessage("{PropertyName} - Webhook event reference should not be empty.");

            RuleFor(x => x.Message)
                .NotNull()
                .WithMessage("{PropertyName} - Message is required.")
                .NotEmpty()
                .WithMessage("{PropertyName} - Message should not be empty.");

            RuleFor(x => x.Links)
                .NotNull()
                .WithMessage("{PropertyName} - Links is required.")
                .NotEmpty()
                .WithMessage("{PropertyName} - Links should not be empty.");
        }
    }
}
