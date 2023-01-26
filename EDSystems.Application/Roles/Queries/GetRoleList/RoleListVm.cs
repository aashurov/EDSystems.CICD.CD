using System.Collections.Generic;

namespace EDSystems.Application.Roles.Queries.GetRoleList;

public class RoleListVm
{
    public IList<RoleListLookupDto> Roles { get; set; }
}