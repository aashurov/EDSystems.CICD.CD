using AutoMapper;
using AutoMapper.QueryableExtensions;
using EDSystems.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace EDSystems.Application.EDSystems.Queries.Branches.GetBranchList;

public class GetBranchListQueryHandler : IRequestHandler<GetBranchListQuery, BranchListVm>
{
    private readonly IEDSystemsDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetBranchListQueryHandler(IEDSystemsDbContext dbContext, IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<BranchListVm> Handle(GetBranchListQuery request, CancellationToken cancellationToken)
    {
        var branchesQuery = await _dbContext.Branch
            .ProjectTo<BranchLookupDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
        return new BranchListVm { Branches = branchesQuery };
    }
}