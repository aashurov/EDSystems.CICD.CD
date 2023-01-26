using AutoMapper;
using AutoMapper.QueryableExtensions;
using EDSystems.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace EDSystems.Application.EDSystems.Queries.Statuses.GetStatusList;

public class GetStatusListQueryHandler : IRequestHandler<GetStatusListQuery, StatusListVm>
{
    private readonly IEDSystemsDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetStatusListQueryHandler(IEDSystemsDbContext dbContext, IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<StatusListVm> Handle(GetStatusListQuery request, CancellationToken cancellationToken)
    {
        var statusesQuery = await _dbContext.Status
            .ProjectTo<StatusLookupDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
        return new StatusListVm { Statuses = statusesQuery };
    }
}