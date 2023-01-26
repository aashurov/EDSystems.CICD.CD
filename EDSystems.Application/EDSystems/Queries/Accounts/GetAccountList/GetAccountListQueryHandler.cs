using AutoMapper;
using AutoMapper.QueryableExtensions;
using EDSystems.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace EDSystems.Application.EDSystems.Queries.Accounts.GetAccountList;

public class GetAccountListQueryHandler : IRequestHandler<GetAccountListQuery, AccountListVm>
{
    private readonly IEDSystemsDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetAccountListQueryHandler(IEDSystemsDbContext dbContext, IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<AccountListVm> Handle(GetAccountListQuery request, CancellationToken cancellationToken)
    {
        var accountsQuery = await _dbContext.Account
            .ProjectTo<AccountLookupDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
        return new AccountListVm { Accounts = accountsQuery };
    }
}