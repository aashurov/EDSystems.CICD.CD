using System.Collections.Generic;

namespace EDSystems.Application.EDSystems.Queries.Plans.GetPlanList;

public class PlanListVm
{
    public IList<PlanLookupDto> Plans { get; set; }
}