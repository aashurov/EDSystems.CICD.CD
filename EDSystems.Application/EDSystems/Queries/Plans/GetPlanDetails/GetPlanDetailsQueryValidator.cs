using FluentValidation;

namespace EDSystems.Application.EDSystems.Queries.Plans.GetPlanDetails;

public class GetPlanDetailsQueryValidator : AbstractValidator<GetPlanDetailsQuery>
{
    public GetPlanDetailsQueryValidator()
    {
        RuleFor(plan => plan.Id).GreaterThan(0);
    }
}