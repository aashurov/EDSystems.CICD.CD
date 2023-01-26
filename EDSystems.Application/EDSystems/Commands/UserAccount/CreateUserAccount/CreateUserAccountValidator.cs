using FluentValidation;

namespace EDSystems.Application.EDSystems.Commands.Accounts.CreateAccount;

public class CreateUserAccountValidator : AbstractValidator<CreateUserAccountCommand>
{
    public CreateUserAccountValidator()
    {
        RuleFor(createUserAccountCommand => createUserAccountCommand.Name).NotEmpty().MaximumLength(250).NotEqual(string.Empty);
        RuleFor(createUserAccountCommand => createUserAccountCommand.Number).NotEmpty().MaximumLength(1024).NotEqual(string.Empty);
    }
}