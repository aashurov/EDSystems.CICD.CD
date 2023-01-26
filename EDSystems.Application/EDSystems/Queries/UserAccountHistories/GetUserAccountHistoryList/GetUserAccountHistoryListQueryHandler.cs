using AutoMapper;
using AutoMapper.QueryableExtensions;
using EDSystems.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace EDSystems.Application.EDSystems.Queries.UserAccountHistories.GetUserAccountHistoryList;

public class GetUserAccountHistoryListQueryHandler : IRequestHandler<GetUserAccountHistoryListQuery, UserAccountHistoryListVm>
{
    private readonly IEDSystemsDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetUserAccountHistoryListQueryHandler(IEDSystemsDbContext dbContext, IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<UserAccountHistoryListVm> Handle(GetUserAccountHistoryListQuery request, CancellationToken cancellationToken)
    {
        var userAccountHistoryQuery = await _dbContext.UserAccountHistory
            .ProjectTo<UserAccountHistoryLookupDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
        return new UserAccountHistoryListVm { UserAccountHistory = userAccountHistoryQuery };
    }
}