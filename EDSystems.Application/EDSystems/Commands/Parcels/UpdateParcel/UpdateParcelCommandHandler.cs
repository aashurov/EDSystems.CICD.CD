using EDSystems.Application.Common.Exceptions;
using EDSystems.Application.Interfaces;
using EDSystems.Domain.Entities;
using EDSystems.Domain.Entities.UserEntities;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace EDSystems.Application.EDSystems.Commands.Parcels.UpdateParcel;

public class UpdateParcelCommandHandler : IRequestHandler<UpdateParcelCommand, Unit>
{
    private readonly IEDSystemsDbContext _dbContext;
    private readonly IWebHostEnvironment _env;
    private readonly UserManager<User> _userManager;

    public UpdateParcelCommandHandler(IEDSystemsDbContext dbContext, IWebHostEnvironment env, UserManager<User> userManager) => (_dbContext, _env, _userManager) = (dbContext, env, userManager);

    public async Task<Unit> Handle(UpdateParcelCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Parcel
                                     .Include(p => p.ParcelPlan).ThenInclude(e => e.Plan)
                                     .Include(r => r.ParcelCost)
                                     .Include(t => t.ParcelOwners)
                                     .Include(z => z.ParcelBranch).ThenInclude(e => e.FromBranch)
                                     .Include(z => z.ParcelBranch).ThenInclude(e => e.ToBranch)
                                     .Include(e => e.ParcelSize)
                                     .Include(y => y.ParcelStatus).ThenInclude(e => e.Status)
                                     .Include(o => o.ParcelImage)
                                     .Include(o => o.ParcelSound)
                                     .Include(o => o.ParcelDescription)
                                     .FirstOrDefaultAsync(parcel => parcel.Id == request.Id, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Parcel), request.Id);
        }

        entity.ParcelPlan.Plan = _dbContext.Plan.FindAsync(request.ParcelPlanId).Result;
        entity.ParcelSize = request.ParcelSize;
        entity.ParcelBranch.FromBranch = _dbContext.Branch.FindAsync(request.ParcelBranchFromId).Result;
        entity.ParcelBranch.ToBranch = _dbContext.Branch.FindAsync(request.ParcelBranchToId).Result;

        foreach (var file in entity.ParcelImage)
        {
            //await System.IO.File.WriteAllBytesAsync("wwwroot/" + Code + "_" + i + "." + extension, bytes);
            if (File.Exists(_env.WebRootPath + "\\MainImages\\" + file.ImageName))
            {
                File.Delete(_env.WebRootPath + "\\MainImages\\" + file.ImageName);
            }
        }

        int i = 0;
        foreach (var MyImage in request.ParcelImage)
        {
            i++;
            var index = MyImage.ImageBytes.IndexOf(',');
            var base64stringWhiouSignature = MyImage.ImageBytes.Substring(index + 1);

            index = MyImage.ImageBytes.IndexOf(';');

            var base64Signature = MyImage.ImageBytes.Substring(0, index);
            index = base64Signature.IndexOf('/');
            var extension = base64Signature.Substring(index + 1);

            byte[] bytes = Convert.FromBase64String(base64stringWhiouSignature);

            await File.WriteAllBytesAsync(_env.WebRootPath + "\\MainImages\\" + entity.Code + "_" + i + "." + extension, bytes);
            MyImage.ImageName = entity.Code + "_" + i + "." + extension;
        }

        if (request.ParcelSound.Count > 0)
        {
            foreach (var MySound in request.ParcelSound)
            {
                i++;
                var index = MySound.SoundBytes.IndexOf(',');
                var base64stringWhiouSignature = MySound.SoundBytes.Substring(index + 1);

                index = MySound.SoundBytes.IndexOf(';');

                var base64Signature = MySound.SoundBytes.Substring(0, index);
                index = base64Signature.IndexOf('/');
                var extension = base64Signature.Substring(index + 1);

                byte[] bytes = Convert.FromBase64String(base64stringWhiouSignature);

                await File.WriteAllBytesAsync(_env.WebRootPath + "\\MainSounds\\" + entity.Code + "_" + i + "." + extension, bytes);
                MySound.SoundName = entity.Code + "_" + i + "." + extension;
            }
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
                throw new NotFoundException(nameof(Status), request.Id);
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
            entity.ParcelCost.CostDeliveryToBranch = request.ParcelCost.CostDeliveryToBranch;

            //zabor
            entity.ParcelCost.StatePickingUp = true;
            entity.ParcelCost.CostPickingUp = request.ParcelCost.CostPickingUp;

            //opldopl
            entity.ParcelCost.StateDeliveryToPoint = true;
            entity.ParcelCost.CostDeliveryToPoint = request.ParcelCost.CostDeliveryToPoint;

            //vikup
            entity.ParcelCost.StateBuyout = true;
            entity.ParcelCost.CostBuyout = request.ParcelCost.CostBuyout;
        }
        else if (request.ParcelStatusId != 13)
        {
            entity.ParcelCost = request.ParcelCost;
        }

        ////for zabor u kurera
        //if (request.ParcelStatusId == 11)
        //{
        //    if (string.IsNullOrEmpty(request.SenderCourierId) || string.IsNullOrWhiteSpace(request.SenderCourierId))
        //    {
        //        throw new NotFoundException(nameof(Status), request.Id);
        //    }
        //    else
        //    {
        //        entity.ParcelOwners.SenderCourier = _userManager.FindByIdAsync(request.SenderCourierId).Result;
        //    }
        //}
        //else if (request.ParcelStatusId != 11)
        //{
        //    entity.ParcelOwners.SenderCourier = null;
        //}

        ///Recepient staffni ushlab quyish kerak httpCpontextdan
        entity.ParcelOwners.RecepientStaff = _userManager.FindByIdAsync(request.RecepientStaffId).Result;
        ///Sender staffni ushlab quyish kerak httpCpontextdan
        entity.ParcelOwners.SenderStaff = _userManager.FindByIdAsync(request.SenderStaffId).Result;

        entity.ParcelOwners.Recepient = _userManager.FindByIdAsync(request.RecepientId).Result;
        entity.ParcelOwners.Sender = _userManager.FindByIdAsync(request.SenderId).Result;

        entity.ParcelImage = request.ParcelImage;
        entity.ParcelDescription = request.ParcelDescription;
        await _dbContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}