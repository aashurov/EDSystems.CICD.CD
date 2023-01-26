using AutoMapper;
using AutoMapper.QueryableExtensions;
using EDSystems.Application.Common.Mappings;
using EDSystems.Application.Common.Models;
using EDSystems.Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EDSystems.Application.EDSystems.Queries.Statuses.GetStatusListWithPagination;

public class GetStatusListWithPaginationQueryHandler : IRequestHandler<GetStatusListWithPaginationQuery, PaginatedList<StatusLookupDtoWithPagination>>
{
    private readonly IEDSystemsDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetStatusListWithPaginationQueryHandler(IEDSystemsDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<PaginatedList<StatusLookupDtoWithPagination>> Handle(GetStatusListWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _dbContext.Status
            .ProjectTo<StatusLookupDtoWithPagination>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}