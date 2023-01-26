using FluentValidation;

namespace EDSystems.Application.EDSystems.Commands.Accounts.UpdateAccount;

public class UpdateAccountCommandValidator : AbstractValidator<UpdateAccountCommand>
{
    public UpdateAccountCommandValidator()
    {
        RuleFor(updateAccountCommand => updateAccountCommand.Id).GreaterThan(0);
        RuleFor(updateAccountCommand => updateAccountCommand.Name).NotEmpty().MaximumLength(250);
    }
}