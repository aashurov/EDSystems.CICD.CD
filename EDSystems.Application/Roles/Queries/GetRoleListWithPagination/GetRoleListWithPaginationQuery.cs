using EDSystems.Application.Common.Models;
using MediatR;

namespace EDSystems.Application.Roles.Queries.GetRoleListWithPagination;

public class GetRoleListWithPaginationQuery : IRequest<PaginatedList<RoleListLookupDtoWithPagination>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}