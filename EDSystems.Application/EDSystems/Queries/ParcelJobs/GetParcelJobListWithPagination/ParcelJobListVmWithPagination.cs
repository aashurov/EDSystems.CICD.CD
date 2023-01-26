using System.Collections.Generic;

namespace EDSystems.Application.EDSystems.Queries.ParcelJobs.GetParcelJobListWithPagination;

public class ParcelJobListVmWithPagination
{
    public IList<ParcelJobLookupDtoWithPagination> ParcelJobs { get; set; }
}