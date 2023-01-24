using EDSystems.Application.Common.Models;
using MediatR;

namespace EDSystems.Application.EDSystems.Queries.AccountsHistory.GetAccountHistoryListWithPagination;

public class GetAccountHistoryListWithPaginationQuery : IRequest<PaginatedList<AccountHistoryLookupDtoWithPagination>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}