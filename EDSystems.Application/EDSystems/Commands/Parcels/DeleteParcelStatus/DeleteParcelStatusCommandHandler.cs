using EDSystems.Application.Common.Exceptions;
using EDSystems.Application.Interfaces;
using EDSystems.Domain.Entities;
using EDSystems.Domain.Entities.UserEntities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace EDSystems.Application.EDSystems.Commands.Parcels.DeleteParcelStatus;

public class DeleteParcelStatusCommandHandler : IRequestHandler<DeleteParcelStatusCommand>
{
    private readonly IEDSystemsDbContext _dbContext;
    private readonly UserManager<User> _userManager;

    public DeleteParcelStatusCommandHandler(IEDSystemsDbContext dbContext, UserManager<User> userManager) => (_dbContext, _userManager) = (dbContext, userManager);

    public async Task<Unit> Handle(DeleteParcelStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Parcel
                                      .Include(r => r.ParcelCost)
                                      .Include(t => t.ParcelOwners)
                                      .Include(y => y.ParcelStatus).ThenInclude(e => e.Status)
                                      .FirstOrDefaultAsync(parcel => parcel.Id == request.ParcelId, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Parcel), request.ParcelId);
        }

        //for na dostavke u kurera
        if (request.ParcelStatusId == 11)
        {
            if (string.IsNullOrEmpty(request.RecepientCourierId) || string.IsNullOrWhiteSpace(request.RecepientCourierId))
            {
                throw new NotFoundException(nameof(Status), request.ParcelId);
            }
            else
            {
                entity.ParcelOwners.RecepientCourier = null;
            }
        }

        //for Dostavlen
        if (request.ParcelStatusId == 13)
        {
            //do filiala
            entity.ParcelCost.StateDeliveryToBranch = false;

            //zabor
            entity.ParcelCost.StatePickingUp = false;

            //opldopl
            entity.ParcelCost.StateDeliveryToPoint = false;

            //vikup
            entity.ParcelCost.StateBuyout = false;
        }

        var status = await _dbContext.ParcelStatus.FindAsync(request.ParcelStatusId);
        _dbContext.ParcelStatus.Remove(status);

        await _dbContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}