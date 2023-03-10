using EDSystems.Application.Common.Exceptions;
using EDSystems.Application.Interfaces;
using EDSystems.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace EDSystems.Application.EDSystems.Commands.Branches.UpdateBranch;

public class UpdateBranchCommandHandler : IRequestHandler<UpdateBranchCommand, Unit>
{
    private readonly IEDSystemsDbContext _dbContext;
    private readonly ICustomLoggingBehavoir _customLoggingBehavior;
    private static readonly string _ClassName = nameof(UpdateBranchCommandHandler);
    private readonly ICacheService _cacheService;


    public UpdateBranchCommandHandler(IEDSystemsDbContext dbContext,
                                      ICustomLoggingBehavoir customLoggingBehavior,
                                      ICacheService cacheService)
    {   _dbContext = dbContext;
        _customLoggingBehavior = customLoggingBehavior;
        _cacheService = cacheService; }
    

    public async Task<Unit> Handle(UpdateBranchCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Branch.FirstOrDefaultAsync(branch => branch.Id == request.Id, cancellationToken);

        _cacheService.RemoveData($"Branch/{request.Id}");

        if (entity == null)
        {
            throw new NotFoundException(nameof(Branch), request.Id);
        }

        entity.Name = request.Name;
        entity.Country = request.Country;
        entity.Code = request.Code;
        entity.City = request.City;
        entity.Address = request.Address;
        entity.Email = request.Email;
        entity.Phone = request.Phone;

        var result = await _dbContext.SaveChangesAsync(cancellationToken);
        if (result > 0)
        {
            _customLoggingBehavior.WriteToFileSuccess(_ClassName, entity);
        }
        return Unit.Value;
    }
}