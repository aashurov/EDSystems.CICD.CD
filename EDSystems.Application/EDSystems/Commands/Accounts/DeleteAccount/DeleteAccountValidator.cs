using FluentValidation;

namespace EDSystems.Application.EDSystems.Commands.Accounts.DeleteAccount;

public class DeleteAccountCommandValidator : AbstractValidator<DeleteAccountCommand>
{
    public DeleteAccountCommandValidator()
    {
        RuleFor(deleteAccountCommand => deleteAccountCommand.Id).GreaterThan(0);
    }
}