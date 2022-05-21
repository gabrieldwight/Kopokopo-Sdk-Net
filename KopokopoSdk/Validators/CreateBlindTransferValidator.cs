using FluentValidation;
using KopokopoSdk.Requests;

namespace KopokopoSdk.Validators
{
    public class CreateBlindTransferValidator : AbstractValidator<CreateBlindTransferRequest>
    {
        public CreateBlindTransferValidator()
        {
            RuleFor(x => x.Links)
               .NotNull()
               .WithMessage("{PropertyName} - Link is required.")
               .NotEmpty()
               .WithMessage("{PropertyName} - Link should not be empty.");
        }
    }
}
