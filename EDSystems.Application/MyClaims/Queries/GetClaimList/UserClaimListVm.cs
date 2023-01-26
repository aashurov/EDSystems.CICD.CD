using System.Collections.Generic;

namespace EDSystems.Application.Claims.Queries.GetClaimList;

public class UserClaimListVm
{
    public IList<System.Security.Claims.Claim> Claim { get; set; }
    //public IList<UserClaimLookupDto> Claims { get; set; }
}