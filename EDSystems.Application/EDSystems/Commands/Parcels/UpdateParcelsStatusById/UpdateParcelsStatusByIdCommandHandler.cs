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

namespace EDSystems.Application.EDSystems.Commands.Parcels.UpdateParcelsStatusById;

public class UpdateParcelsStatusByIdCommandHandler : IRequestHandler<UpdateParcelsStatusByIdCommand>
{
    private readonly IEDSystemsDbContext _dbContext;
    private readonly UserManager<User> _userManager;

    public UpdateParcelsStatusByIdCommandHandler(IEDSystemsDbContext dbContext, UserManager<User> userManager) => (_dbContext, _userManager) = (dbContext, userManager);

    public async Task<Unit> Handle(UpdateParcelsStatusByIdCommand request, CancellationToken cancellationToken)
    {
        foreach (var entitymine in request.ParcelId)
        {
            var entity = await _dbContext.Parcel
                                      .Include(r => r.ParcelCost)
                                      .Include(t => t.ParcelOwners)
                                      .Include(y => y.ParcelStatus).ThenInclude(e => e.Status)
                                      .FirstOrDefaultAsync(parcel => parcel.Id == entitymine, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Parcel), entity.Id);
            }

            var pst = new ParcelStatus
            {
                Parcel = entity,
                DateUpdated = DateTime.Now,
                Status = await _dbContext.Status.FindAsync(request.StatusId)
            };

            bool tt = false;
            foreach (var item in entity.ParcelStatus)
            {
                if (item.Status.Id == request.StatusId)
                {
                    tt = true;
                }
            }

            if (tt == false)
            {
                entity.ParcelStatus.Add(pst);
            }

            //for na dostavke u kurera
            if (request.StatusId == 11)
            {
                if (string.IsNullOrEmpty(request.RecepientCourierId) || string.IsNullOrWhiteSpace(request.RecepientCourierId))
                {
                    throw new NotFoundException(nameof(Status), entity.Id);
                }
                else
                {
                    entity.ParcelOwners.RecepientCourier = _userManager.FindByIdAsync(request.RecepientCourierId).Result;
                }
            }
            else if (request.StatusId != 11)
            {
                entity.ParcelOwners.RecepientCourier = null;
            }

            //for Dostavlen
            if (request.StatusId == 13)
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
            else if (request.StatusId != 13)
            {
            }

            ///Recepient staffni ushlab quyish kerak httpCpontextdan
            entity.ParcelOwners.RecepientStaff = _userManager.FindByIdAsync(request.RecepientStaffId).Result;
            ///Sender staffni ushlab quyish kerak httpCpontextdan
            entity.ParcelOwners.SenderStaff = _userManager.FindByIdAsync(request.SenderStaffId).Result;

            entity.ParcelOwners.Recepient = _userManager.FindByIdAsync(request.RecepientId).Result;
            entity.ParcelOwners.Sender = _userManager.FindByIdAsync(request.SenderId).Result;
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
        return Unit.Value;
    }
}