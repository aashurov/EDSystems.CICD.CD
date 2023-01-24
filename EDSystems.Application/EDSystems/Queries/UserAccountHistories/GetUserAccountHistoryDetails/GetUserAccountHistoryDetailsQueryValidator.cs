using FluentValidation;

namespace EDSystems.Application.EDSystems.Queries.UserAccountHistories.GetUserAccountHistoryDetails;

public class GetUserAccountHistoryDetailsQueryValidator : AbstractValidator<GetUserAccountHistoryDetailsQuery>
{
    public GetUserAccountHistoryDetailsQueryValidator()
    {
        RuleFor(account => account.Id).GreaterThan(0);
    }
}