using AutoMapper;
using AutoMapper.QueryableExtensions;
using EDSystems.Application.Common.Mappings;
using EDSystems.Application.Common.Models;
using EDSystems.Application.Interfaces;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EDSystems.Application.EDSystems.Queries.Accounts.GetAccountListWithPagination;

public class GetAccountListWithPaginationQueryHandler : IRequestHandler<GetAccountListWithPaginationQuery, PaginatedList<AccountLookupDtoWithPagination>>
{
    private readonly IEDSystemsDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetAccountListWithPaginationQueryHandler(IEDSystemsDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<PaginatedList<AccountLookupDtoWithPagination>> Handle(GetAccountListWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _dbContext.Account.OrderBy(x=>x.Id)
            .ProjectTo<AccountLookupDtoWithPagination>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}