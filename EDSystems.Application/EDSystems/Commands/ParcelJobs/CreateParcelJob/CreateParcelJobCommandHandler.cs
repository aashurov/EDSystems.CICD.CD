using EDSystems.Application.Interfaces;
using EDSystems.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EDSystems.Application.EDSystems.Commands.ParcelJobs.CreateParcelJob;

public class CreateParcelJobCommandHandler : IRequestHandler<CreateParcelJobCommand, int>
{
    private readonly IEDSystemsDbContext _dbContext;
    private readonly ICustomLoggingBehavoir _customLoggingBehavior;
    private static readonly string _ClassName = nameof(CreateParcelJobCommandHandler);

    public CreateParcelJobCommandHandler(IEDSystemsDbContext dbContext, ICustomLoggingBehavoir customLoggingBehavior) => (_dbContext, _customLoggingBehavior) = (dbContext, customLoggingBehavior);

    public async Task<int> Handle(CreateParcelJobCommand request, CancellationToken cancellationToken)
    {
        var parcelJob = new ParcelJob
        {
            ParcelId = request.ParcelId,
            CourierId = request.CourierId,
            Cost = request.Cost,
            JobType = request.JobType,
            PaymentState = request.PaymentState,
        };
        await _dbContext.ParcelJob.AddAsync(parcelJob, cancellationToken);
        var result = await _dbContext.SaveChangesAsync(cancellationToken);
        if (result > 0)
        {
            _customLoggingBehavior.WriteToFileSuccess(_ClassName, parcelJob);
        }
        return parcelJob.Id;
    }
}