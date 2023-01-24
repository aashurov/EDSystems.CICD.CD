using System.Collections.Generic;

namespace EDSystems.Application.EDSystems.Queries.ParcelJobs.GetParcelJobList;

public class ParcelJobListVm
{
    public IList<ParcelJobLookupDto> ParcelJobs { get; set; }
}