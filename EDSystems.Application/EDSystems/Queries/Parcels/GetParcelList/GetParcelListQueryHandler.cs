using AutoMapper;
using AutoMapper.QueryableExtensions;
using EDSystems.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace EDSystems.Application.EDSystems.Queries.Parcels.GetParcelList;

public class GetParcelListQueryHandler : IRequestHandler<GetParcelListQuery, ParcelListVm>
{
    private readonly IEDSystemsDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetParcelListQueryHandler(IEDSystemsDbContext dbContext, IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<ParcelListVm> Handle(GetParcelListQuery request, CancellationToken cancellationToken)
    {
        var parcelQuery = await _dbContext.Parcel
            .Include(w => w.ParcelBranch).ThenInclude(e => e.FromBranch)
            .Include(w => w.ParcelBranch).ThenInclude(e => e.ToBranch)
            .Include(w => w.ParcelCost)
            .Include(w => w.ParcelDescription)
            .Include(w => w.ParcelImage)
            .Include(w => w.ParcelSound)
            .Include(w => w.ParcelItem)
            .Include(w => w.ParcelOwners).ThenInclude(x => x.Sender)
            .Include(w => w.ParcelOwners).ThenInclude(x => x.SenderStaff)
            .Include(w => w.ParcelOwners).ThenInclude(x => x.SenderCourier)
            .Include(w => w.ParcelOwners).ThenInclude(x => x.Recepient)
            .Include(w => w.ParcelOwners).ThenInclude(x => x.RecepientStaff)
            //.Include(w => w.ParcelOwners).ThenInclude(x => new { x.Sender, x.SenderStaff, x.SenderCourier, x.Recepient, x.RecepientStaff, x.RecepientCourier })
            .Include(w => w.ParcelPlan).ThenInclude(y => y.Plan)
            .Include(w => w.ParcelSize)
            .Include(w => w.ParcelStatus).ThenInclude(e => e.Status)

            .ProjectTo<ParcelLookupDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
        return new ParcelListVm { Parcels = parcelQuery };
    }
}