using System.Collections.Generic;

namespace EDSystems.Application.EDSystems.Queries.AccountsHistory.GetAccountHistoryListWithPagination;

public class AccountHistoryListVmWithPagination
{
    public IList<AccountHistoryLookupDtoWithPagination> AccountHistory { get; set; }
}