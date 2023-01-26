using EDSystems.Application.Common.Models;
using System.Collections.Generic;

namespace EDSystems.Application.Roles.Queries.GetRoleListWithPagination;

public class RoleListVmWithPagination
{
    public IList<PaginatedList<RoleListLookupDtoWithPagination>> Roles { get; set; }
}