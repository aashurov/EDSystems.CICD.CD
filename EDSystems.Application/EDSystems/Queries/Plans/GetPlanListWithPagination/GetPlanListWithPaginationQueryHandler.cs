using AutoMapper;
using AutoMapper.QueryableExtensions;
using EDSystems.Application.Common.Mappings;
using EDSystems.Application.Common.Models;
using EDSystems.Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EDSystems.Application.EDSystems.Queries.Plans.GetPlanListWithPagination;

public class GetPlanListWithPaginationQueryHandler : IRequestHandler<GetPlanListWithPaginationQuery, PaginatedList<PlanLookupDtoWithPagination>>
{
    private readonly IEDSystemsDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetPlanListWithPaginationQueryHandler(IEDSystemsDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<PaginatedList<PlanLookupDtoWithPagination>> Handle(GetPlanListWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _dbContext.Plan
            .ProjectTo<PlanLookupDtoWithPagination>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}