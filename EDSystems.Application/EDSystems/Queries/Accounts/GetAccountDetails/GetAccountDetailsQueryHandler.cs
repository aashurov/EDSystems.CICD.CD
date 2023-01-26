using AutoMapper;
using EDSystems.Application.Common.Exceptions;
using EDSystems.Application.Interfaces;
using EDSystems.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace EDSystems.Application.EDSystems.Queries.Accounts.GetAccountDetails;

public class GetAccountDetailsQueryHandler
: IRequestHandler<GetAccountDetailsQuery, AccountDetailsVm>
{
    private readonly IEDSystemsDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetAccountDetailsQueryHandler(IEDSystemsDbContext dbContext, IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<AccountDetailsVm> Handle(GetAccountDetailsQuery request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Account
                                        .Include(account => account.Branch)
                                        .Include(account => account.Currency)
                                        .Include(account => account.AccountHistory)
                                        .FirstOrDefaultAsync(account => account.Id == request.Id, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Account), request.Id);
        }
        return _mapper.Map<AccountDetailsVm>(entity);
    }
}