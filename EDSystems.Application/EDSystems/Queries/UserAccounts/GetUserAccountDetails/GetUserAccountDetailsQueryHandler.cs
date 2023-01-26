using AutoMapper;
using EDSystems.Application.Common.Exceptions;
using EDSystems.Application.Interfaces;
using EDSystems.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace EDSystems.Application.EDSystems.Queries.UserAccounts.GetUserAccountDetails;

public class GetUserAccountDetailsQueryHandler
: IRequestHandler<GetUserAccountDetailsQuery, UserAccountDetailsVm>
{
    private readonly IEDSystemsDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetUserAccountDetailsQueryHandler(IEDSystemsDbContext dbContext, IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<UserAccountDetailsVm> Handle(GetUserAccountDetailsQuery request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.UserAccount
                                        .Include(account => account.Currency)
                                        .Include(account => account.User)
                                        .FirstOrDefaultAsync(account => account.Id == request.Id, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(UserAccount), request.Id);
        }
        return _mapper.Map<UserAccountDetailsVm>(entity);
    }
}