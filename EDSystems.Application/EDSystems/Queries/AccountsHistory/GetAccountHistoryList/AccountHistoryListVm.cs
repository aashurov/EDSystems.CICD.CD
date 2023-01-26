using System.Collections.Generic;

namespace EDSystems.Application.EDSystems.Queries.AccountsHistory.GetAccountHistoryList;

public class AccountHistoryListVm
{
    public IList<AccountHistoryLookupDto> AccountHistory { get; set; }
}