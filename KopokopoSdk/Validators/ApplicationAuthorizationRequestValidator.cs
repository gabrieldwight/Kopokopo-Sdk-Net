using FluentValidation;
using KopokopoSdk.Requests;

namespace KopokopoSdk.Validators
{
    public class ApplicationAuthorizationRequestValidator : AbstractValidator<KopokopoApplicationAuthorizationRequest>
    {
        public ApplicationAuthorizationRequestValidator()
        {
            RuleFor(x => x.ClientId)
                .NotNull()
                .WithMessage("{PropertyName} - Client Id is required.")
                .NotEmpty()
                .WithMessage("{PropertyName} - Client Id should not be empty.");

            RuleFor(x => x.ClientSecret)
                .NotNull()
                .WithMessage("{PropertyName} - Client secret is required.")
                .NotEmpty()
                .WithMessage("{PropertyName} - Client secret should not be empty.");

            RuleFor(x => x.GrantType)
                .NotNull()
                .WithMessage("{PropertyName} - Grant type is required.")
                .NotEmpty()
                .WithMessage("{PropertyName} - Grant type should not be empty.");

        }
    }
}
