using EDSystems.Application.Common.Exceptions;
using EDSystems.Application.Interfaces;
using EDSystems.Domain.Entities;
using EDSystems.Domain.Entities.UserEntities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EDSystems.Application.EDSystems.Commands.Parcels.AddParcelStatus;

public class AddParcelStatusCommandHandler : IRequestHandler<AddParcelStatusCommand>
{
    private readonly IEDSystemsDbContext _dbContext;
    private readonly UserManager<User> _userManager;

    public AddParcelStatusCommandHandler(IEDSystemsDbContext dbContext, UserManager<User> userManager) => (_dbContext, _userManager) = (dbContext, userManager);

    public async Task<Unit> Handle(AddParcelStatusCommand request, CancellationToken cancellationToken)
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

        var pst = new ParcelStatus
        {
            Parcel = entity,
            DateUpdated = DateTime.Now,
            Status = await _dbContext.Status.FindAsync(request.ParcelStatusId)
        };

        bool tt = false;
        foreach (var item in entity.ParcelStatus)
        {
            if (item.Status.Id == request.ParcelStatusId)
            {
                tt = true;
            }
        }

        if (tt == false)
        {
            entity.ParcelStatus.Add(pst);
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
                entity.ParcelOwners.RecepientCourier = _userManager.FindByIdAsync(request.RecepientCourierId).Result;
            }
        }
        else if (request.ParcelStatusId != 11)
        {
            entity.ParcelOwners.RecepientCourier = null;
        }

        //for Dostavlen
        if (request.ParcelStatusId == 13)
        {
            //do filiala
            entity.ParcelCost.StateDeliveryToBranch = true;

            //zabor
            entity.ParcelCost.StatePickingUp = true;

            //opldopl
            entity.ParcelCost.StateDeliveryToPoint = true;

            //vikup
            entity.ParcelCost.StateBuyout = true;
        }
        else if (request.ParcelStatusId != 13)
        {
        }

        ///Recepient staffni ushlab quyish kerak httpCpontextdan
        entity.ParcelOwners.RecepientStaff = _userManager.FindByIdAsync(request.RecepientStaffId).Result;
        ///Sender staffni ushlab quyish kerak httpCpontextdan
        entity.ParcelOwners.SenderStaff = _userManager.FindByIdAsync(request.SenderStaffId).Result;

        entity.ParcelOwners.Recepient = _userManager.FindByIdAsync(request.RecepientId).Result;
        entity.ParcelOwners.Sender = _userManager.FindByIdAsync(request.SenderId).Result;
        await _dbContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}