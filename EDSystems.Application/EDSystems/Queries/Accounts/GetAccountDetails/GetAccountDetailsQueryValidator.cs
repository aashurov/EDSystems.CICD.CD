using FluentValidation;

namespace EDSystems.Application.EDSystems.Queries.Accounts.GetAccountDetails;

public class GetAccountDetailsQueryValidator : AbstractValidator<GetAccountDetailsQuery>
{
    public GetAccountDetailsQueryValidator()
    {
        RuleFor(accountDetails => accountDetails.Id).GreaterThan(0);
    }
}