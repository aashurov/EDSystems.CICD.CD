using AutoMapper;
using AutoMapper.QueryableExtensions;
using EDSystems.Application.Common.Mappings;
using EDSystems.Application.Common.Models;
using EDSystems.Application.EDSystems.Queries.Parcels.GetParcelList;
using EDSystems.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace EDSystems.Application.EDSystems.Queries.Parcels.GetParcelListWithPagination
{
    public class GetParcelListWithPaginationQueryHandler : IRequestHandler<GetParcelListWithPaginationQuery, PaginatedList<ParcelLookupDto>>
    {
        private readonly IEDSystemsDbContext _dbContext;

        private readonly IMapper _mapper;

        public GetParcelListWithPaginationQueryHandler(IEDSystemsDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<PaginatedList<ParcelLookupDto>> Handle(GetParcelListWithPaginationQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Parcel
                   .Include(w => w.ParcelBranch).ThenInclude(e => e.FromBranch)
                   .Include(w => w.ParcelBranch).ThenInclude(e => e.ToBranch)
                   .Include(w => w.ParcelCost)
                   .Include(w => w.ParcelDescription)
                   .Include(w => w.ParcelImage)
                   .Include(w => w.ParcelSound)
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
                   .PaginatedListAsync(request.PageNumber, request.PageSize);
        }
    }
}