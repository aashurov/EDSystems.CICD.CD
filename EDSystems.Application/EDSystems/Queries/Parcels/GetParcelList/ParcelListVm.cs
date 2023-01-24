using System.Collections.Generic;

namespace EDSystems.Application.EDSystems.Queries.Parcels.GetParcelList;

public class ParcelListVm
{
    public IList<ParcelLookupDto> Parcels { get; set; }
}