using EDSystems.Application.Common.Models;
using MediatR;

namespace EDSystems.Application.EDSystems.Queries.Branches.GetBranchListWithPagination;

public class GetBranchListWithPaginationQuery : IRequest<PaginatedList<BranchLookupDtoWithPagination>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}