using FluentValidation;

namespace EDSystems.Application.EDSystems.Commands.Plans.CreatePlan;

public class CreatePlanCommandValidator : AbstractValidator<CreatePlanCommand>
{
    public CreatePlanCommandValidator()
    {
        RuleFor(createPlanCommand => createPlanCommand.Name).NotEmpty().MaximumLength(250).NotEqual(string.Empty);
        //RuleFor(createPlanCommand => createPlanCommand.Cost).ScalePrecision(3, 2).NotEmpty();
        RuleFor(createPlanCommand => createPlanCommand.Description).MinimumLength(2).NotEmpty().WithMessage("Description not be empty");
    }
}