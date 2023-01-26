using System.Collections.Generic;

namespace EDSystems.Application.Users.Queries.GetUserList;

public class UserListVm
{
    public IList<UserLookupDto> Customers { get; set; }
}