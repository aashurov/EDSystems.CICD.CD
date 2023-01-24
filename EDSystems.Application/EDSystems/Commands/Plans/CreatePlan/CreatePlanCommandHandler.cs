using EDSystems.Application.Interfaces;
using EDSystems.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EDSystems.Application.EDSystems.Commands.Plans.CreatePlan;

public class CreatePlanCommandHandler : IRequestHandler<CreatePlanCommand, int>
{
    private readonly IEDSystemsDbContext _dbContext;

    public CreatePlanCommandHandler(IEDSystemsDbContext dbContext) => _dbContext = dbContext;

    public async Task<int> Handle(CreatePlanCommand request, CancellationToken cancellationToken)
    {
        var plan = new Plan
        {
            Name = request.Name,
            Cost = request.Cost,
            Description = request.Description,
            DateUpdated = null
        };
        await _dbContext.Plan.AddAsync(plan, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return plan.Id;
    }
}