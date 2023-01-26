using EDSystems.Application.EDSystems.Queries.Accounts.GetAccountList;
using FluentValidation;

namespace EDSystems.Application.EDSystems.Queries.AccountsHistory.GetAccountHistoryList;

public class GetAccountHistoryListQueryValidator : AbstractValidator<GetAccountListQuery>
{
    public GetAccountHistoryListQueryValidator()
    {
    }
}