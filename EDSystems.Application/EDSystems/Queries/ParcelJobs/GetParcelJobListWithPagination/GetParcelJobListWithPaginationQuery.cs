using EDSystems.Application.Common.Models;
using MediatR;

namespace EDSystems.Application.EDSystems.Queries.ParcelJobs.GetParcelJobListWithPagination;

public class GetParcelJobListWithPaginationQuery : IRequest<PaginatedList<ParcelJobLookupDtoWithPagination>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}