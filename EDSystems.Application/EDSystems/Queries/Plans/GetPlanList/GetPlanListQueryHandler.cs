using AutoMapper;
using AutoMapper.QueryableExtensions;
using EDSystems.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace EDSystems.Application.EDSystems.Queries.Plans.GetPlanList;

public class GetBranchListQueryHandler : IRequestHandler<GetPlanListQuery, PlanListVm>
{
    private readonly IEDSystemsDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetBranchListQueryHandler(IEDSystemsDbContext dbContext, IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<PlanListVm> Handle(GetPlanListQuery request, CancellationToken cancellationToken)
    {
        var plansQuery = await _dbContext.Plan
            .ProjectTo<PlanLookupDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
        return new PlanListVm { Plans = plansQuery };
    }
}