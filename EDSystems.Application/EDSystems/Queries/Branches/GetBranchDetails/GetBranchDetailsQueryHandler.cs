using AutoMapper;
using EDSystems.Application.Common.Exceptions;
using EDSystems.Application.Interfaces;
using EDSystems.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace EDSystems.Application.EDSystems.Queries.Branches.GetBranchDetails;

public class GetBranchDetailsQueryHandler
    : IRequestHandler<GetBranchDetailsQuery, BranchDetailsVm>
{
    private readonly IEDSystemsDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetBranchDetailsQueryHandler(IEDSystemsDbContext dbContext, IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<BranchDetailsVm> Handle(GetBranchDetailsQuery request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Branch.FirstOrDefaultAsync(branch => branch.Id == request.Id, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Branch), request.Id);
        }
        return _mapper.Map<BranchDetailsVm>(entity);
    }
}