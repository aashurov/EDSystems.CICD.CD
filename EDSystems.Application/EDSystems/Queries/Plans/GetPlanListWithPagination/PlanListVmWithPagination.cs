using EDSystems.Application.Common.Models;
using System.Collections.Generic;

namespace EDSystems.Application.EDSystems.Queries.Plans.GetPlanListWithPagination;

public class PlanListVmWithPagination
{
    public IList<PaginatedList<PlanLookupDtoWithPagination>> Plans { get; set; }
}