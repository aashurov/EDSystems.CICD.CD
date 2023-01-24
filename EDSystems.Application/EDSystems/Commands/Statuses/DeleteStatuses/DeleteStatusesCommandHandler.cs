using EDSystems.Application.Common.Exceptions;
using EDSystems.Application.Interfaces;
using EDSystems.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EDSystems.Application.EDSystems.Commands.Statuses.DeleteStatuses;

public class DeleteStatusesCommandHandler : IRequestHandler<DeleteStatusesCommand>
{
    private readonly IEDSystemsDbContext _dbContext;

    public DeleteStatusesCommandHandler(IEDSystemsDbContext dbContext) => _dbContext = dbContext;

    public async Task<Unit> Handle(DeleteStatusesCommand request, CancellationToken cancellationToken)
    {
        foreach (var item in request.Id)
        {
            var entity = await _dbContext.Status.FindAsync(new object[] { item }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Status), request.Id);
            }
            _dbContext.Status.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
        return Unit.Value;
    }
}