using FluentValidation;

namespace EDSystems.Application.EDSystems.Commands.Accounts.CreateAccount;

public class CreateAccountValidator : AbstractValidator<CreateAccountCommand>
{
    public CreateAccountValidator()
    {
        RuleFor(createAccountCommand => createAccountCommand.Name).NotEmpty().MaximumLength(250).NotEqual(string.Empty);
        RuleFor(createAccountCommand => createAccountCommand.Number).NotEmpty().MaximumLength(1024).NotEqual(string.Empty);
    }
}