using FluentValidation;

namespace EDSystems.Application.EDSystems.Queries.Parcels.GetParcelDetails;

public class GetParcelDetailsQueryValidator : AbstractValidator<GetParcelDetailsQuery>
{
    public GetParcelDetailsQueryValidator()
    {
        RuleFor(parcel => parcel.Id).GreaterThan(0);
    }
}