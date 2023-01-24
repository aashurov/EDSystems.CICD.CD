using System.Collections.Generic;

namespace EDSystems.Application.EDSystems.Queries.UserAccountHistories.GetUserAccountHistoryList;

public class UserAccountHistoryListVm
{
    public IList<UserAccountHistoryLookupDto> UserAccountHistory { get; set; }
}