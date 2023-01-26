using EDSystems.Application.EDSystems.Commands.Accounts.DeleteUserAccount;
using FluentValidation;

namespace EDSystems.Application.EDSystems.Commands.Accounts.DeleteAccount;

public class DeleteUserAccountCommandValidator : AbstractValidator<DeleteUserAccountCommand>
{
    public DeleteUserAccountCommandValidator()
    {
        RuleFor(deleteAccountCommand => deleteAccountCommand.Id).GreaterThan(0);
    }
}