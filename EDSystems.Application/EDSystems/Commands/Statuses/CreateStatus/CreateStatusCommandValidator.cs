using FluentValidation;

namespace EDSystems.Application.EDSystems.Commands.Statuses.CreateStatus;

public class CreateStatusCommandValidator : AbstractValidator<CreateStatusCommand>
{
    public CreateStatusCommandValidator()
    {
        RuleFor(createPlanCommand => createPlanCommand.Name).NotEmpty().MaximumLength(250).NotEqual(string.Empty);
        RuleFor(createPlanCommand => createPlanCommand.Description).MinimumLength(500);
    }
}