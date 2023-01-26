using AutoMapper;
using AutoMapper.QueryableExtensions;
using EDSystems.Application.Common.Mappings;
using EDSystems.Application.Common.Models;
using EDSystems.Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EDSystems.Application.EDSystems.Queries.AccountsHistory.GetAccountHistoryListWithPagination;

public class GetAccountHistoryListWithPaginationQueryHandler : IRequestHandler<GetAccountHistoryListWithPaginationQuery, PaginatedList<AccountHistoryLookupDtoWithPagination>>
{
    private readonly IEDSystemsDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetAccountHistoryListWithPaginationQueryHandler(IEDSystemsDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<PaginatedList<AccountHistoryLookupDtoWithPagination>> Handle(GetAccountHistoryListWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _dbContext.AccountHistory
            .ProjectTo<AccountHistoryLookupDtoWithPagination>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}