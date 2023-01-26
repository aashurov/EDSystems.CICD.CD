using EDSystems.Application.Common.Models;
using System.Collections.Generic;

namespace EDSystems.Application.EDSystems.Queries.Branches.GetBranchListWithPagination;

public class BranchListVmWithPagination
{
    public IList<PaginatedList<BranchLookupDtoWithPagination>> Branches { get; set; }
}