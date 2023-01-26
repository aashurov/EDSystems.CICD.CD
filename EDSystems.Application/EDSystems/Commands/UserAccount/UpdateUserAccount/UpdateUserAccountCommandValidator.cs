using FluentValidation;

namespace EDSystems.Application.EDSystems.Commands.Accounts.UpdateUserAccount;

public class UpdateUserAccountCommandValidator : AbstractValidator<UpdateUserAccountCommand>
{
    public UpdateUserAccountCommandValidator()
    {
        RuleFor(updateAccountCommand => updateAccountCommand.Id).GreaterThan(0);
        RuleFor(updateAccountCommand => updateAccountCommand.Name).NotEmpty().MaximumLength(250);
    }
}