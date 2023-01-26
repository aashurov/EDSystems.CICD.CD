using AutoMapper;
using EDSystems.Application.Common.Exceptions;
using EDSystems.Application.Interfaces;
using EDSystems.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace EDSystems.Application.EDSystems.Queries.Statuses.GetStatusDetails;

public class GetStatusDetailsQueryHandler
    : IRequestHandler<GetStatusDetailsQuery, StatusDetailsVm>
{
    private readonly IEDSystemsDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetStatusDetailsQueryHandler(IEDSystemsDbContext dbContext, IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<StatusDetailsVm> Handle(GetStatusDetailsQuery request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Status.FirstOrDefaultAsync(status => status.Id == request.Id, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Status), request.Id);
        }
        return _mapper.Map<StatusDetailsVm>(entity);
    }
}