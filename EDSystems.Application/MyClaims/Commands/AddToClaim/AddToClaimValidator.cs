using FluentValidation;

namespace EDSystems.Application.EDSystems.Commands.MyClaims.AddToClaim;

public class AddToClaimValidator : AbstractValidator<AddToClaimCommand>
{
    public AddToClaimValidator()
    {
        RuleFor(addToClaimCommand => addToClaimCommand.ClaimValue).NotEmpty().MaximumLength(250).NotEqual(string.Empty);
        RuleFor(addToClaimCommand => addToClaimCommand.ClaimName).NotEmpty().MaximumLength(1024).NotEqual(string.Empty);
        RuleFor(addToClaimCommand => addToClaimCommand.Email).NotEmpty().MaximumLength(250).NotEqual(string.Empty);
    }
}