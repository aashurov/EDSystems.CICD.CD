using AutoMapper;
using AutoMapper.QueryableExtensions;
using EDSystems.Application.Common.Mappings;
using EDSystems.Application.Common.Models;
using EDSystems.Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EDSystems.Application.EDSystems.Queries.UserAccountHistories.GetUserAccountHistoryListWithPagination;

public class GetUserAccountHistoryListWithPaginationQueryHandler : IRequestHandler<GetUserAccountHistoryListWithPaginationQuery, PaginatedList<UserAccountHistoryLookupDtoWithPagination>>
{
    private readonly IEDSystemsDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetUserAccountHistoryListWithPaginationQueryHandler(IEDSystemsDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<PaginatedList<UserAccountHistoryLookupDtoWithPagination>> Handle(GetUserAccountHistoryListWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _dbContext.UserAccountHistory
            .ProjectTo<UserAccountHistoryLookupDtoWithPagination>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}