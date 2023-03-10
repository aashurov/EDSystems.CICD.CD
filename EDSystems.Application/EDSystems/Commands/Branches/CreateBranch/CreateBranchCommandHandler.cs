using EDSystems.Application.Interfaces;
using EDSystems.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EDSystems.Application.EDSystems.Commands.Branches.CreateBranch;

public class CreateBranchCommandHandler : IRequestHandler<CreateBranchCommand, int>
{
    private readonly IEDSystemsDbContext _dbContext;
    private readonly ICustomLoggingBehavoir _customLoggingBehavior;
    private static readonly string _ClassName = nameof(CreateBranchCommandHandler);
    private readonly ICacheService _cacheService;

    public CreateBranchCommandHandler(IEDSystemsDbContext dbContext, ICustomLoggingBehavoir customLoggingBehavior, ICacheService cacheService) => (_dbContext, _customLoggingBehavior, _cacheService) = (dbContext, customLoggingBehavior, cacheService);

    public async Task<int> Handle(CreateBranchCommand request, CancellationToken cancellationToken)
    {
        var branch = new Branch
        {
            Name = request.Name, 
            Country = request.Country, 
            Code = request.Code,
            City = request.City,
            Address = request.Address,
            Email = request.Email, 
            Phone = request.Phone, 
        };

        var addObj = await _dbContext.Branch.AddAsync(branch, cancellationToken);

        var expiryTime = DateTimeOffset.Now.AddMinutes(10);
        _cacheService.SetData($"branch/{branch.Id}", addObj.Entity, expiryTime);

        var result = await _dbContext.SaveChangesAsync(cancellationToken);
        
        if (result > 0)
        {
            _customLoggingBehavior.WriteToFileSuccess(_ClassName, branch);
        }
        
        return branch.Id;
    
}
}