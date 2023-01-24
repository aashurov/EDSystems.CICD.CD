using EDSystems.Application.EDSystems.Queries.Parcels.GetParcelList;
using System.Collections.Generic;

namespace EDSystems.Application.EDSystems.Queries.Parcels.GetParcelListWithPagination
{
    public class ParcelListVmWithPagination
    {
        public IList<ParcelLookupDto> ParcelsWithPagination { get; set; }
    }
}