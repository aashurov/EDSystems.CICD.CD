using FluentValidation;

namespace EDSystems.Application.EDSystems.Commands.Plans.UpdatePlan;

public class UpdatePlanCommandValidator : AbstractValidator<UpdatePlanCommand>
{
    public UpdatePlanCommandValidator()
    {
        RuleFor(updatePlanCommand => updatePlanCommand.Id).GreaterThan(0);
        RuleFor(updatePlanCommand => updatePlanCommand.Name).NotEmpty().MaximumLength(250).NotEqual(string.Empty);
        RuleFor(updatePlanCommand => updatePlanCommand.Cost).ScalePrecision(18, 4).NotEmpty();
        RuleFor(updatePlanCommand => updatePlanCommand.Description).MinimumLength(500);
    }
}