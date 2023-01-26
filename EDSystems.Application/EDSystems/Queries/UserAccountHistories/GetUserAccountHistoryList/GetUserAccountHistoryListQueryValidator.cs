using EDSystems.Application.EDSystems.Queries.UserAccounts.GetUserAccountList;
using FluentValidation;

namespace EDSystems.Application.EDSystems.Queries.UserAccountHistories.GetUserAccountHistoryList;

public class GetUserAccountHistoryListQueryValidator : AbstractValidator<GetUserAccountListQuery>
{
    public GetUserAccountHistoryListQueryValidator()
    {
    }
}