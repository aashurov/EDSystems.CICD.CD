using System.Collections.Generic;

namespace EDSystems.Application.EDSystems.Queries.Accounts.GetAccountList;

public class AccountListVm
{
    public IList<AccountLookupDto> Accounts { get; set; }
}