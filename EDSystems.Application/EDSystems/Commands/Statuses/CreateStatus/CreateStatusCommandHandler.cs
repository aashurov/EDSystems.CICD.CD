using EDSystems.Application.Interfaces;
using EDSystems.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EDSystems.Application.EDSystems.Commands.Statuses.CreateStatus;

public class CreateStatusCommandHandler : IRequestHandler<CreateStatusCommand, int>
{
    private readonly IEDSystemsDbContext _dbContext;

    public CreateStatusCommandHandler(IEDSystemsDbContext dbContext) => _dbContext = dbContext;

    public async Task<int> Handle(CreateStatusCommand request, CancellationToken cancellationToken)
    {
        var status = new Status
        {
            Name = request.Name,
            Description = request.Description,
            DateUpdated = null
        };
        await _dbContext.Status.AddAsync(status, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return status.Id;
    }
}