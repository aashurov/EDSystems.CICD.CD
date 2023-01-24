using FluentValidation;

namespace EDSystems.Application.EDSystems.Queries.AccountsHistory.GetAccountHistoryDetails;

public class GetAccountHistoryDetailsQueryValidator : AbstractValidator<GetAccountHistoryDetailsQuery>
{
    public GetAccountHistoryDetailsQueryValidator()
    {
        RuleFor(account => account.Id).GreaterThan(0);
    }
}