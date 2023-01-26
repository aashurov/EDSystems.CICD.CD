using EDSystems.Application.Common.Exceptions;
using EDSystems.Application.Interfaces;
using EDSystems.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace EDSystems.Application.EDSystems.Commands.Plans.UpdatePlan;

public class UpdatePlanCommandHandler : IRequestHandler<UpdatePlanCommand>
{
    private readonly IEDSystemsDbContext _dbContext;

    public UpdatePlanCommandHandler(IEDSystemsDbContext dbContext) => _dbContext = dbContext;

    public async Task<Unit> Handle(UpdatePlanCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Plan.FirstOrDefaultAsync(plan => plan.Id == request.Id, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Plan), request.Id);
        }

        entity.Name = request.Name;
        entity.Cost = request.Cost;
        entity.Description = request.Description;
        entity.DateUpdated = System.DateTime.Now;

        await _dbContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}