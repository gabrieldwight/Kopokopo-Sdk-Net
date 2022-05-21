using FluentValidation;
using KopokopoSdk.Requests;

namespace KopokopoSdk.Validators
{
    public class CreateMerchantMobileWalletValidator : AbstractValidator<CreateMerchantMobileWalletRequest>
    {
        public CreateMerchantMobileWalletValidator()
        {
            RuleFor(x => x.Network)
               .NotNull()
               .WithMessage("{PropertyName} - Network is required.")
               .NotEmpty()
               .WithMessage("{PropertyName} - Network should not be empty.");

            RuleFor(x => x.FirstName)
                .NotNull()
                .WithMessage("{PropertyName} - First Name is required.")
                .NotEmpty()
                .WithMessage("{PropertyName} - First Name should not be empty.");

            RuleFor(x => x.LastName)
                .NotNull()
                .WithMessage("{PropertyName} - Last Name is required.")
                .NotEmpty()
                .WithMessage("{PropertyName} - Last Name should not be empty.");

            RuleFor(x => x.PhoneNumber)
                .NotNull()
                .WithMessage("{PropertyName} - Phone number is required.")
                .NotEmpty()
                .WithMessage("{PropertyName} - Phone number should not be empty.");
        }
    }
}
