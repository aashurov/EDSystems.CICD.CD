using System.Collections.Generic;

namespace EDSystems.Application.EDSystems.Queries.Statuses.GetStatusList;

public class StatusListVm
{
    public IList<StatusLookupDto> Statuses { get; set; }
}