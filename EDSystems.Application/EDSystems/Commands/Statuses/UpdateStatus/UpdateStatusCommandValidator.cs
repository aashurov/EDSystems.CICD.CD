using FluentValidation;

namespace EDSystems.Application.EDSystems.Commands.Statuses.UpdateStatus;

public class UpdateStatusCommandValidator : AbstractValidator<UpdateStatusCommand>
{
    public UpdateStatusCommandValidator()
    {
        RuleFor(updateStatusCommand => updateStatusCommand.Id).GreaterThan(0);
        RuleFor(updateStatusCommand => updateStatusCommand.Name).NotEmpty().MaximumLength(250).NotEqual(string.Empty);
        RuleFor(updateStatusCommand => updateStatusCommand.Description).MinimumLength(500);
    }
}