using AutoMapper;
using EDSystems.Application.Common.Exceptions;
using EDSystems.Application.Interfaces;
using EDSystems.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace EDSystems.Application.EDSystems.Queries.AccountsHistory.GetAccountHistoryDetails;

public class GetAccountHistoryDetailsQueryHandler
: IRequestHandler<GetAccountHistoryDetailsQuery, AccountHistoryDetailsVm>
{
    private readonly IEDSystemsDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetAccountHistoryDetailsQueryHandler(IEDSystemsDbContext dbContext, IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<AccountHistoryDetailsVm> Handle(GetAccountHistoryDetailsQuery request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.AccountHistory
                                        .Include(account => account.BranchAccount)
                                        .Include(account => account.Currency)
                                        .Include(account => account.Payer)
                                        .Include(account => account.Parcel)
                                        .FirstOrDefaultAsync(account => account.Id == request.Id, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Account), request.Id);
        }
        return _mapper.Map<AccountHistoryDetailsVm>(entity);
    }
}