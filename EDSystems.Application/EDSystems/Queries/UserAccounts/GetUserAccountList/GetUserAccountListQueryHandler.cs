using AutoMapper;
using AutoMapper.QueryableExtensions;
using EDSystems.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace EDSystems.Application.EDSystems.Queries.UserAccounts.GetUserAccountList;

public class GetUserAccountListQueryHandler : IRequestHandler<GetUserAccountListQuery, UserAccountListVm>
{
    private readonly IEDSystemsDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetUserAccountListQueryHandler(IEDSystemsDbContext dbContext, IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<UserAccountListVm> Handle(GetUserAccountListQuery request, CancellationToken cancellationToken)
    {
        var userAccountsQuery = await _dbContext.UserAccount
            .ProjectTo<UserAccountLookupDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
        return new UserAccountListVm { UserAccounts = userAccountsQuery };
    }
}