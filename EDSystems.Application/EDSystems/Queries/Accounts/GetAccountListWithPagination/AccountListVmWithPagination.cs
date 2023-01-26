using System.Collections.Generic;

namespace EDSystems.Application.EDSystems.Queries.Accounts.GetAccountListWithPagination;

public class AccountListVmWithPagination
{
    public IList<AccountLookupDtoWithPagination> Accounts { get; set; }
}