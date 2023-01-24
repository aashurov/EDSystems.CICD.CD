using AutoMapper;
using AutoMapper.QueryableExtensions;
using EDSystems.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace EDSystems.Application.EDSystems.Queries.ParcelJobs.GetParcelJobList;

public class GetParcelJobListQueryHandler : IRequestHandler<GetParcelJobListQuery, ParcelJobListVm>
{
    private readonly IEDSystemsDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetParcelJobListQueryHandler(IEDSystemsDbContext dbContext, IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<ParcelJobListVm> Handle(GetParcelJobListQuery request, CancellationToken cancellationToken)
    {
        var branchesQuery = await _dbContext.ParcelJob
            .ProjectTo<ParcelJobLookupDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
        return new ParcelJobListVm { ParcelJobs = branchesQuery };
    }
}