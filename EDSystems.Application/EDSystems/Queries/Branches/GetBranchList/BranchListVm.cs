using System.Collections.Generic;

namespace EDSystems.Application.EDSystems.Queries.Branches.GetBranchList;

public class BranchListVm
{
    public IList<BranchLookupDto> Branches { get; set; }
}