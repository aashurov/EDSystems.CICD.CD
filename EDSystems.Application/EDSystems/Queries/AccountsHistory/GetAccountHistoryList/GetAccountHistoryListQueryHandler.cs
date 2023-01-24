using AutoMapper;
using AutoMapper.QueryableExtensions;
using EDSystems.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace EDSystems.Application.EDSystems.Queries.AccountsHistory.GetAccountHistoryList;

public class GetAccountHistoryListQueryHandler : IRequestHandler<GetAccountHistoryListQuery, AccountHistoryListVm>
{
    private readonly IEDSystemsDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetAccountHistoryListQueryHandler(IEDSystemsDbContext dbContext, IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<AccountHistoryListVm> Handle(GetAccountHistoryListQuery request, CancellationToken cancellationToken)
    {
        var accountHistoryQuery = await _dbContext.AccountHistory
            .ProjectTo<AccountHistoryLookupDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
        return new AccountHistoryListVm { AccountHistory = accountHistoryQuery };
    }
}