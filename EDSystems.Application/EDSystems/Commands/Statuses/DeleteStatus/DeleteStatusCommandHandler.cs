using EDSystems.Application.Common.Exceptions;
using EDSystems.Application.Interfaces;
using EDSystems.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EDSystems.Application.EDSystems.Commands.Statuses.DeleteStatus;

public class DeleteStatusCommandHandler : IRequestHandler<DeleteStatusCommand, Unit>
{
    private readonly IEDSystemsDbContext _dbContext;

    public DeleteStatusCommandHandler(IEDSystemsDbContext dbContext) => _dbContext = dbContext;

    public async Task<Unit> Handle(DeleteStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Status.FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Status), request.Id);
        }
        _dbContext.Status.Remove(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}