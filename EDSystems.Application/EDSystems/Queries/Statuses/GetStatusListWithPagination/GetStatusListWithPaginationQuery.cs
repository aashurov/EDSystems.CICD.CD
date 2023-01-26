using EDSystems.Application.Common.Models;
using MediatR;

namespace EDSystems.Application.EDSystems.Queries.Statuses.GetStatusListWithPagination;

public class GetStatusListWithPaginationQuery : IRequest<PaginatedList<StatusLookupDtoWithPagination>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}