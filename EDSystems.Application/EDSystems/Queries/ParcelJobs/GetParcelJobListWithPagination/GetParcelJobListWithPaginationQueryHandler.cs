using AutoMapper;
using AutoMapper.QueryableExtensions;
using EDSystems.Application.Common.Mappings;
using EDSystems.Application.Common.Models;
using EDSystems.Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EDSystems.Application.EDSystems.Queries.ParcelJobs.GetParcelJobListWithPagination;

public class GetParcelJobListWithPaginationQueryHandler : IRequestHandler<GetParcelJobListWithPaginationQuery, PaginatedList<ParcelJobLookupDtoWithPagination>>
{
    private readonly IEDSystemsDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetParcelJobListWithPaginationQueryHandler(IEDSystemsDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<PaginatedList<ParcelJobLookupDtoWithPagination>> Handle(GetParcelJobListWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _dbContext.Branch
            .ProjectTo<ParcelJobLookupDtoWithPagination>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}