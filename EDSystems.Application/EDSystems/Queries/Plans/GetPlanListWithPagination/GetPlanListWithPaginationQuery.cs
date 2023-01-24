using EDSystems.Application.Common.Models;
using MediatR;

namespace EDSystems.Application.EDSystems.Queries.Plans.GetPlanListWithPagination;

public class GetPlanListWithPaginationQuery : IRequest<PaginatedList<PlanLookupDtoWithPagination>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}