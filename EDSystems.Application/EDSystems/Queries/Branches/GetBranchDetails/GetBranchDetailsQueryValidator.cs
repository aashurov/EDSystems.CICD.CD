using FluentValidation;

namespace EDSystems.Application.EDSystems.Queries.Branches.GetBranchDetails;

public class GetBranchDetailsQueryValidator : AbstractValidator<GetBranchDetailsQuery>
{
    public GetBranchDetailsQueryValidator()
    {
        RuleFor(branch => branch.Id).GreaterThan(0);
    }
}