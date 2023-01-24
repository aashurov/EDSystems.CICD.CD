using AutoMapper;
using EDSystems.Application.Common.Exceptions;
using EDSystems.Application.Interfaces;
using EDSystems.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace EDSystems.Application.EDSystems.Queries.Plans.GetPlanDetails;

public class GetPlanDetailsQueryHandler
    : IRequestHandler<GetPlanDetailsQuery, PlanDetailsVm>
{
    private readonly IEDSystemsDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetPlanDetailsQueryHandler(IEDSystemsDbContext dbContext, IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<PlanDetailsVm> Handle(GetPlanDetailsQuery request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Plan.FirstOrDefaultAsync(plan => plan.Id == request.Id, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Plan), request.Id);
        }
        return _mapper.Map<PlanDetailsVm>(entity);
    }
}