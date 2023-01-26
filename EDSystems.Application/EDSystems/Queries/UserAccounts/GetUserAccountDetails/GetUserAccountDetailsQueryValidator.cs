using FluentValidation;

namespace EDSystems.Application.EDSystems.Queries.UserAccounts.GetUserAccountDetails;

public class GetUserAccountDetailsQueryValidator : AbstractValidator<GetUserAccountDetailsQuery>
{
    public GetUserAccountDetailsQueryValidator()
    {
        RuleFor(account => account.Id).GreaterThan(0);
    }
}