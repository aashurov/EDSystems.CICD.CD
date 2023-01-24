using AutoMapper;
using AutoMapper.QueryableExtensions;
using EDSystems.Application.Common.Mappings;
using EDSystems.Application.Common.Models;
using EDSystems.Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EDSystems.Application.EDSystems.Queries.UserAccounts.GetUserAccountListWithPagination;

public class GetUserAccountListWithPaginationQueryHandler : IRequestHandler<GetUserAccountListWithPaginationQuery, PaginatedList<UserAccountLookupDtoWithPagination>>
{
    private readonly IEDSystemsDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetUserAccountListWithPaginationQueryHandler(IEDSystemsDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<PaginatedList<UserAccountLookupDtoWithPagination>> Handle(GetUserAccountListWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _dbContext.UserAccount
            .ProjectTo<UserAccountLookupDtoWithPagination>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}