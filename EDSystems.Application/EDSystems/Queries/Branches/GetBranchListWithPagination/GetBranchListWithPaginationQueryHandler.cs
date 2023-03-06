using AutoMapper;
using AutoMapper.QueryableExtensions;
using EDSystems.Application.Common.Mappings;
using EDSystems.Application.Common.Models;
using EDSystems.Application.Interfaces;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EDSystems.Application.EDSystems.Queries.Branches.GetBranchListWithPagination;

public class GetBranchListWithPaginationQueryHandler : IRequestHandler<GetBranchListWithPaginationQuery, PaginatedList<BranchLookupDtoWithPagination>>
{
    private readonly IEDSystemsDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetBranchListWithPaginationQueryHandler(IEDSystemsDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<PaginatedList<BranchLookupDtoWithPagination>> Handle(GetBranchListWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _dbContext.Branch.OrderBy(x => x.Id)
            .ProjectTo<BranchLookupDtoWithPagination>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}