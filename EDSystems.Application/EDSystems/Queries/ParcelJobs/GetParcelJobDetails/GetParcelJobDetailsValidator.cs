using FluentValidation;

namespace EDSystems.Application.EDSystems.Queries.ParcelJobs.GetParcelJobDetails;

public class GetParcelJobDetailsValidator : AbstractValidator<GetParcelJobDetailsQuery>
{
    public GetParcelJobDetailsValidator()
    {
        RuleFor(parcelJobDetail => parcelJobDetail.Id).GreaterThan(0);
    }
}