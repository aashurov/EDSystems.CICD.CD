using EDSystems.Application.Common.Exceptions;
using EDSystems.Application.Interfaces;
using EDSystems.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace EDSystems.Application.EDSystems.Commands.ParcelJobs.UpdateParcelJob;

public class UpdateParcelJobCommandHandler : IRequestHandler<UpdateParcelJobCommand>
{
    private static readonly string _ClassName = nameof(UpdateParcelJobCommandHandler);
    private readonly ICustomLoggingBehavoir _customLoggingBehavior;
    private readonly IEDSystemsDbContext _dbContext;

    public UpdateParcelJobCommandHandler(IEDSystemsDbContext dbContext, ICustomLoggingBehavoir customLoggingBehavior) => (_dbContext, _customLoggingBehavior) = (dbContext, customLoggingBehavior);

    public async Task<Unit> Handle(UpdateParcelJobCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.ParcelJob.FirstOrDefaultAsync(branch => branch.Id == request.Id, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(ParcelJob), request.Id);
        }

        entity.Cost = request.Cost;
        entity.PaymentState = request.PaymentState;
        entity.CourierId = request.CourierId;
        entity.JobType = request.JobType;
        entity.ParcelId = request.ParcelId;

        var result = await _dbContext.SaveChangesAsync(cancellationToken);
        if (result > 0)
        {
            _customLoggingBehavior.WriteToFileSuccess(_ClassName, entity);
        }
        return Unit.Value;
    }
}