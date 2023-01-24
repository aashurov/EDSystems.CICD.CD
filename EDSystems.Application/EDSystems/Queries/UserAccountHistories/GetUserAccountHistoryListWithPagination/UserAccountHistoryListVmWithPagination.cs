using System.Collections.Generic;

namespace EDSystems.Application.EDSystems.Queries.UserAccountHistories.GetUserAccountHistoryListWithPagination;

public class UserAccountHistoryListVmWithPagination
{
    public IList<UserAccountHistoryLookupDtoWithPagination> UserAccountHistory { get; set; }
}