using System.Collections.Generic;

namespace EDSystems.Application.EDSystems.Queries.UserAccounts.GetUserAccountList;

public class UserAccountListVm
{
    public IList<UserAccountLookupDto> UserAccounts { get; set; }
}