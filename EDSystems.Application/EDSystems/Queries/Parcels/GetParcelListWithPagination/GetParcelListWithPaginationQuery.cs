using EDSystems.Application.Common.Models;
using EDSystems.Application.EDSystems.Queries.Parcels.GetParcelList;
using MediatR;

namespace EDSystems.Application.EDSystems.Queries.Parcels.GetParcelListWithPagination
{
    public class GetParcelListWithPaginationQuery : IRequest<PaginatedList<ParcelLookupDto>>
    {
        public int PageNumber { get; init; } = 1;
        public int PageSize { get; init; } = 10;
    }
}