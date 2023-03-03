using EDSystems.Application.Common.Exceptions;
using EDSystems.Application.Interfaces;
using EDSystems.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EDSystems.Application.EDSystems.Commands.ParcelJobs.DeleteParcelJob;

public class DeleteParcelJobCommandHandler : IRequestHandler<DeleteParcelJobCommand, Unit>
{
    private readonly IEDSystemsDbContext _dbContext;
    private readonly ICustomLoggingBehavoir _customLoggingBehavior;
    private static readonly string _ClassName = nameof(DeleteParcelJobCommandHandler);

    public DeleteParcelJobCommandHandler(IEDSystemsDbContext dbContext, ICustomLoggingBehavoir customLoggingBehavior) => (_dbContext, _customLoggingBehavior) = (dbContext, customLoggingBehavior);

    public async Task<Unit> Handle(DeleteParcelJobCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.ParcelJob.FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(ParcelJob), request.Id);
        }
        _dbContext.ParcelJob.Remove(entity);
        var result = await _dbContext.SaveChangesAsync(cancellationToken);

        if (result > 0)
        {
            _customLoggingBehavior.WriteToFileSuccess(_ClassName, entity);
        }
        return Unit.Value;
    }
}