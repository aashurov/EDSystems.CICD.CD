using AutoMapper;
using EDSystems.Application.Common.Exceptions;
using EDSystems.Application.Interfaces;
using EDSystems.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace EDSystems.Application.EDSystems.Queries.UserAccountHistories.GetUserAccountHistoryDetails;

public class GetUserAccountHistoryDetailsQueryHandler
: IRequestHandler<GetUserAccountHistoryDetailsQuery, UserAccountHistoryDetailsVm>
{
    private readonly IEDSystemsDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetUserAccountHistoryDetailsQueryHandler(IEDSystemsDbContext dbContext, IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<UserAccountHistoryDetailsVm> Handle(GetUserAccountHistoryDetailsQuery request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.UserAccountHistory
                                        .Include(account => account.User)
                                        .Include(account => account.Currency)
                                        .Include(account => account.Parcel)
                                        .FirstOrDefaultAsync(account => account.Id == request.Id, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(UserAccountHistory), request.Id);
        }
        return _mapper.Map<UserAccountHistoryDetailsVm>(entity);
    }
}