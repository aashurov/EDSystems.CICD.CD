using AutoMapper;
using AutoMapper.QueryableExtensions;
using EDSystems.Application.Common.Mappings;
using EDSystems.Application.Common.Models;
using EDSystems.Application.EDSystems.Queries.Branches.GetBranchListWithPagination;
using EDSystems.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EDSystems.Application.EDSystems.Queries.Branches.GetBranchList;

public class GetBranchListQueryHandler : IRequestHandler<GetBranchListQuery, BranchListVm>
{
    private readonly IEDSystemsDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly ICacheService _cacheService;

    public GetBranchListQueryHandler(IEDSystemsDbContext dbContext, IMapper mapper, ICacheService cacheService)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _cacheService = cacheService;
    }

    

    public async Task<BranchListVm> Handle(GetBranchListQuery request, CancellationToken cancellationToken)
    {

        var branchesQuery = await _dbContext.Branch
            .ProjectTo<BranchLookupDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return new BranchListVm { Branches = branchesQuery };


    }
}