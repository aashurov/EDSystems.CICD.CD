using EDSystems.Application.Common.Exceptions;
using EDSystems.Application.Interfaces;
using EDSystems.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EDSystems.Application.EDSystems.Commands.Branches.DeleteBranch;

public class DeleteBranchCommandHandler : IRequestHandler<DeleteBranchCommand, Unit>
{
    private readonly IEDSystemsDbContext _dbContext;

    private readonly ICustomLoggingBehavoir _customLoggingBehavior;

    private static readonly string _ClassName = nameof(DeleteBranchCommandHandler);

    private readonly ICacheService _cacheService;

    public DeleteBranchCommandHandler(IEDSystemsDbContext dbContext,
                                      ICustomLoggingBehavoir customLoggingBehavior,
                                      ICacheService cacheService)
     {
        _dbContext = dbContext;
        _customLoggingBehavior = customLoggingBehavior;
        _cacheService = cacheService;
    }

    public async Task<Unit> Handle(DeleteBranchCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Branch.FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Branch), request.Id);
        }

        _cacheService.RemoveData($"Branch/{request.Id}");

        _dbContext.Branch.Remove(entity);

        var result = await _dbContext.SaveChangesAsync(cancellationToken);

        if (result > 0)
        {
            _customLoggingBehavior.WriteToFileSuccess(_ClassName, entity);
        }
        return Unit.Value;
    }
}