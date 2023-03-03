using EDSystems.Application.Common.Exceptions;
using EDSystems.Application.Interfaces;
using EDSystems.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace EDSystems.Application.EDSystems.Commands.Statuses.UpdateStatus;

public class UpdateStatusCommandHandler : IRequestHandler<UpdateStatusCommand, Unit>
{
    private readonly IEDSystemsDbContext _dbContext;

    public UpdateStatusCommandHandler(IEDSystemsDbContext dbContext) => _dbContext = dbContext;

    public async Task<Unit> Handle(UpdateStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Status.FirstOrDefaultAsync(status => status.Id == request.Id, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Status), request.Id);
        }

        entity.Name = request.Name;
        entity.Description = request.Description;
        entity.DateUpdated = System.DateTime.Now;

        await _dbContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}