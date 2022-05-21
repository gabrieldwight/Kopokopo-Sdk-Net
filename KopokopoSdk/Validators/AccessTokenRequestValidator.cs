using FluentValidation;
using KopokopoSdk.Requests;

namespace KopokopoSdk.Validators
{
    public class AccessTokenRequestValidator : AbstractValidator<KopokopoAccessTokenRequest>
    {
        public AccessTokenRequestValidator()
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

            RuleFor(x => x.Token)
                .NotNull()
                .WithMessage("{PropertyName} - Token is required.")
                .NotEmpty()
                .WithMessage("{PropertyName} - Token should not be empty.");
        }
    }
}
