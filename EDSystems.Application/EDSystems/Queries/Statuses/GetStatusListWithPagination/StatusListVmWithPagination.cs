using EDSystems.Application.Common.Models;
using System.Collections.Generic;

namespace EDSystems.Application.EDSystems.Queries.Statuses.GetStatusListWithPagination;

public class StatusListVmWithPagination
{
    public IList<PaginatedList<StatusLookupDtoWithPagination>> Statuses { get; set; }
}