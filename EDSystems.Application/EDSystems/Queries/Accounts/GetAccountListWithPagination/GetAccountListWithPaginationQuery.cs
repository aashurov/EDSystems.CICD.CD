using EDSystems.Application.Common.Models;
using MediatR;

namespace EDSystems.Application.EDSystems.Queries.Accounts.GetAccountListWithPagination;

public class GetAccountListWithPaginationQuery : IRequest<PaginatedList<AccountLookupDtoWithPagination>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}