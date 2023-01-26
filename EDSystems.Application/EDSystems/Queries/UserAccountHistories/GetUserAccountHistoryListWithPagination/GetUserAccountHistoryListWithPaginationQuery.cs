using EDSystems.Application.Common.Models;
using MediatR;

namespace EDSystems.Application.EDSystems.Queries.UserAccountHistories.GetUserAccountHistoryListWithPagination;

public class GetUserAccountHistoryListWithPaginationQuery : IRequest<PaginatedList<UserAccountHistoryLookupDtoWithPagination>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}