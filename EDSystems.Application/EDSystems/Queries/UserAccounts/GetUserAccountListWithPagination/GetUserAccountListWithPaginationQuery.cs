using EDSystems.Application.Common.Models;
using MediatR;

namespace EDSystems.Application.EDSystems.Queries.UserAccounts.GetUserAccountListWithPagination;

public class GetUserAccountListWithPaginationQuery : IRequest<PaginatedList<UserAccountLookupDtoWithPagination>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}