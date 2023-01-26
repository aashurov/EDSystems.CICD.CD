using AutoMapper;
using EDSystems.Application.Common.Exceptions;
using EDSystems.Application.Interfaces;
using EDSystems.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace EDSystems.Application.EDSystems.Queries.ParcelJobs.GetParcelJobDetails;

public class GetParcelJobDetailsQueryHandler
    : IRequestHandler<GetParcelJobDetailsQuery, ParcelJobDetailsVm>
{
    private readonly IEDSystemsDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetParcelJobDetailsQueryHandler(IEDSystemsDbContext dbContext, IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<ParcelJobDetailsVm> Handle(GetParcelJobDetailsQuery request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.ParcelJob.FirstOrDefaultAsync(parcelJob => parcelJob.Id == request.Id, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(ParcelJob), request.Id);
        }
        return _mapper.Map<ParcelJobDetailsVm>(entity);
    }
}