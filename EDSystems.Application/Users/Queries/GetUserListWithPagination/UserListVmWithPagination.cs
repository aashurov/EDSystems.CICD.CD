using EDSystems.Application.Common.Models;
using System.Collections.Generic;

namespace EDSystems.Application.Users.Queries.GetUserListWithPagination;

public class UserListVmWithPagination
{
    public IList<PaginatedList<UserLookupDtoWithPagination>> Customers { get; set; }
}