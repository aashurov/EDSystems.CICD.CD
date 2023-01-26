using FluentValidation;

namespace EDSystems.Application.EDSystems.Queries.Statuses.GetStatusDetails;

public class GetStatusDetailsQueryValidator : AbstractValidator<GetStatusDetailsQuery>
{
    public GetStatusDetailsQueryValidator()
    {
        RuleFor(status => status.Id).GreaterThan(0);
    }
}