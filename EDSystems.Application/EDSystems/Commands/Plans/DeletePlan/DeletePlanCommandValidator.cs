using EDSystems.Application.EDSystems.Commands.Branches.DeleteBranch;
using FluentValidation;

namespace EDSystems.Application.EDSystems.Commands.Plans.DeletePlan;

public class DeletePlanCommandValidator : AbstractValidator<DeleteBranchCommand>
{
    public DeletePlanCommandValidator()
    {
        RuleFor(deletePlanCommand => deletePlanCommand.Id).GreaterThan(0);
    }
}