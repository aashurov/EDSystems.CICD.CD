using EDSystems.Application.Common.Exceptions;
using EDSystems.Application.Interfaces;
using EDSystems.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EDSystems.Application.EDSystems.Commands.Plans.DeletePlan;

public class DeletePlanCommandHandler : IRequestHandler<DeletePlanCommand, Unit>
{
    private readonly IEDSystemsDbContext _dbContext;

    public DeletePlanCommandHandler(IEDSystemsDbContext dbContext) => _dbContext = dbContext;

    public async Task<Unit> Handle(DeletePlanCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Plan.FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Plan), request.Id);
        }
        _dbContext.Plan.Remove(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}