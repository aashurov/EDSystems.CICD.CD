using EDSystems.Application.Common.Exceptions;
using EDSystems.Application.Interfaces;
using EDSystems.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EDSystems.Application.EDSystems.Commands.Plans.DeletePlans;

public class DeletePlansCommandHandler : IRequestHandler<DeletePlansCommand>
{
    private readonly IEDSystemsDbContext _dbContext;

    public DeletePlansCommandHandler(IEDSystemsDbContext dbContext) => _dbContext = dbContext;

    public async Task<Unit> Handle(DeletePlansCommand request, CancellationToken cancellationToken)
    {
        foreach (var item in request.Id)
        {
            var entity = await _dbContext.Plan.FindAsync(new object[] { item }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Status), request.Id);
            }
            _dbContext.Plan.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
        return Unit.Value;
    }
}