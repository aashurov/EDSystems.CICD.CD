using FluentValidation;

namespace EDSystems.Application.EDSystems.Commands.Statuses.DeleteStatus;

public class DeleteStatusCommandValidator : AbstractValidator<DeleteStatusCommand>
{
    public DeleteStatusCommandValidator()
    {
        RuleFor(deleteStatusCommand => deleteStatusCommand.Id).GreaterThan(0);
    }
}