using EDSystems.Application.Common.Models;
using System.Collections.Generic;

namespace EDSystems.Application.EDSystems.Queries.UserAccounts.GetUserAccountListWithPagination;

public class UserAccountListVmWithPagination
{
    public IList<PaginatedList<UserAccountLookupDtoWithPagination>> UserAccounts { get; set; }
}