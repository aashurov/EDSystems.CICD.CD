using EDSystems.Application.Common.Models;
using MediatR;

namespace EDSystems.Application.Users.Queries.GetUserListWithPagination;

public class GetUserListWithPaginationQuery : IRequest<PaginatedList<UserLookupDtoWithPagination>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}