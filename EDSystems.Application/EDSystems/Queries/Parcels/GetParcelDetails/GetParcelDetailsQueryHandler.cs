using AutoMapper;
using EDSystems.Application.Common.Exceptions;
using EDSystems.Application.Interfaces;
using EDSystems.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace EDSystems.Application.EDSystems.Queries.Parcels.GetParcelDetails;

public class GetParcelDetailsQueryHandler
    : IRequestHandler<GetParcelDetailsQuery, ParcelDetailsVm>
{
    private readonly IEDSystemsDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetParcelDetailsQueryHandler(IEDSystemsDbContext dbContext, IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<ParcelDetailsVm> Handle(GetParcelDetailsQuery request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Parcel
                                            .Include(a => a.ParcelPlan).ThenInclude(a => a.Plan)
                                            .Include(a => a.ParcelCost)
                                            .Include(a => a.ParcelOwners).ThenInclude(e => e.Sender)
                                            .Include(a => a.ParcelOwners).ThenInclude(e => e.SenderStaff)
                                            .Include(a => a.ParcelOwners).ThenInclude(e => e.SenderCourier)
                                            .Include(a => a.ParcelOwners).ThenInclude(e => e.Recepient)
                                            .Include(a => a.ParcelOwners).ThenInclude(e => e.RecepientStaff)
                                            .Include(a => a.ParcelOwners).ThenInclude(e => e.RecepientCourier)
                                            .Include(a => a.ParcelBranch).ThenInclude(a => a.FromBranch)
                                            .Include(a => a.ParcelBranch).ThenInclude(a => a.ToBranch)
                                            .Include(a => a.ParcelSize)
                                            .Include(a => a.ParcelStatus).ThenInclude(a => a.Status)
                                            .Include(a => a.ParcelImage)
                                            .Include(a => a.ParcelSound)
                                            .Include(a => a.ParcelItem)
                                            .Include(a => a.ParcelDescription)
                                            .FirstOrDefaultAsync(parcel => parcel.Id == request.Id, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Parcel), request.Id);
        }
        return _mapper.Map<ParcelDetailsVm>(entity);
    }
}