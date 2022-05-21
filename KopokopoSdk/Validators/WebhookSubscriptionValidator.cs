using FluentValidation;
using KopokopoSdk.Requests;

namespace KopokopoSdk.Validators
{
    public class WebhookSubscriptionValidator : AbstractValidator<WebhookSubscriptionRequest>
    {
        public WebhookSubscriptionValidator()
        {
            RuleFor(x => x.EventType)
               .NotNull()
               .WithMessage("{PropertyName} - Event Type is required.")
               .NotEmpty()
               .WithMessage("{PropertyName} - Event Type should not be empty.");

            RuleFor(x => x.Url)
                .NotNull()
                .WithMessage("{PropertyName} - Url is required.")
                .NotEmpty()
                .WithMessage("{PropertyName} - Url should not be empty.");

            RuleFor(x => x.Scope)
                .NotNull()
                .WithMessage("{PropertyName} - Scope is required.")
                .NotEmpty()
                .WithMessage("{PropertyName} - Scope should not be empty.");

            RuleFor(x => x.ScopeReference)
                .NotNull()
                .WithMessage("{PropertyName} - Scope Reference is required.")
                .NotEmpty()
                .WithMessage("{PropertyName} - Scope Reference should not be empty.");
        }
    }
}
