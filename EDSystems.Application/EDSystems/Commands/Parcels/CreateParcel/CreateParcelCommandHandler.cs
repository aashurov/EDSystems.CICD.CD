using EDSystems.Application.Interfaces;
using EDSystems.Domain.Entities;
using EDSystems.Domain.Entities.UserEntities;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EDSystems.Application.EDSystems.Commands.Parcels.CreateParcel;

public class CreateParcelCommandHandler : IRequestHandler<CreateParcelCommand, int>
{
    private readonly IEDSystemsDbContext _dbContext;
    private readonly UserManager<User> _userManager;
    private IWebHostEnvironment _env;
    private IDateTimeService _dateTimeService;
    private AccountHistory accountHistory;
    private ParcelJob parcelJob;

    public CreateParcelCommandHandler(IEDSystemsDbContext dbContext, IWebHostEnvironment env, UserManager<User> userManager, IDateTimeService dateTimeService)
    {
        _dbContext = dbContext;
        _env = env;
        _userManager = userManager;
        _dateTimeService = dateTimeService;
    }

    public async Task<int> Handle(CreateParcelCommand request, CancellationToken cancellationToken)
    {
        var ParcelStatusList = new List<ParcelStatus>();
        ParcelStatusList.Add(new ParcelStatus() { Status = _dbContext.Status.FindAsync(request.ParcelStatusId).Result });

        Random rnd = new Random();
        int Code = rnd.Next(999999999, 1000000000);
        int i = 0;
        int j = 0;
        if (request.ParcelImage.Count > 0)
        {
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

                await File.WriteAllBytesAsync(_env.WebRootPath + "\\MainImages\\" + Code + "_" + i + "." + extension, bytes);
                MyImage.ImageName = Code + "_" + i + "." + extension;
            }
        }

        if (request.ParcelSound.Count > 0)
        {
            foreach (var MySound in request.ParcelSound)
            {
                j++;
                var index = MySound.SoundBytes.IndexOf(',');
                var base64stringWhiouSignature = MySound.SoundBytes.Substring(index + 1);

                index = MySound.SoundBytes.IndexOf(';');

                var base64Signature = MySound.SoundBytes.Substring(0, index);
                index = base64Signature.IndexOf('/');
                var extension = base64Signature.Substring(index + 1);

                byte[] bytes = Convert.FromBase64String(base64stringWhiouSignature);

                await File.WriteAllBytesAsync(_env.WebRootPath + "\\MainSounds\\" + Code + "_" + j + "." + extension, bytes);
                MySound.SoundName = Code + "_" + j + "." + extension;
            }
        }

        var parcel = new Parcel
        {
            Code = Code,
            ParcelCost = request.ParcelCost,
            ParcelDescription = request.ParcelDescription,
            ParcelImage = request.ParcelImage,
            ParcelSound = request.ParcelSound,
            ParcelItem = request.ParcelItem,

            ParcelPlan = new ParcelPlan()
            {
                PlanId = request.ParcelPlanId
            },

            ParcelOwners = new ParcelOwners()
            {
                RecepientCourierId = request.RecepientCourierId,
                SenderCourierId = request.SenderCourierId,
                RecepientStaffId = request.RecepientStaffId,
                SenderStaffId = request.SenderStaffId,
                RecepientId = request.RecepientId,
                SenderId = request.SenderId
            },
            ParcelBranch = new ParcelBranch()
            {
                FromBranchId = request.ParcelBranchFromId,
                ToBranchId = request.ParcelBranchToId
            },
            ParcelSize = request.ParcelSize,
            ParcelStatus = ParcelStatusList,
            DateCreated = _dateTimeService.Now
        };

        await _dbContext.Parcel.AddAsync(parcel, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        int ParcelId = parcel.Id;

        if (request.ParcelCost.StateBuyout && request.ParcelCost.CostBuyout > 0)
        {
            var result = _dbContext.Account.Where(w => w.BranchId == request.ParcelBranchFromId).Where(w => w.CurrencyId == request.ParcelCost.CurrencyId).FirstOrDefault();
            result.Balance = result.Balance + request.ParcelCost.CostBuyout;
            accountHistory = new AccountHistory()
            {
                BranchAccountId = request.ParcelBranchFromId,
                JobType = true,
                Amount = request.ParcelCost.CostBuyout,
                PayerId = request.RecepientId,
                ParcelId = ParcelId,
                CurrencyId = request.ParcelCost.CurrencyId
            };
        }

        if (request.ParcelCost.StateDeliveryToBranch && request.ParcelCost.CostDeliveryToBranch > 0)
        {
            var result = _dbContext.Account.Where(w => w.BranchId == request.ParcelBranchFromId).Where(w => w.CurrencyId == request.ParcelCost.CurrencyId).FirstOrDefault();
            result.Balance = result.Balance + request.ParcelCost.CostDeliveryToBranch;
            accountHistory = new AccountHistory()
            {
                BranchAccountId = request.ParcelBranchFromId,
                JobType = true,
                Amount = request.ParcelCost.CostDeliveryToBranch,
                PayerId = request.RecepientId,
                ParcelId = ParcelId,
                CurrencyId = request.ParcelCost.CurrencyId
            };
        }

        if (request.ParcelCost.StateDeliveryToPoint && request.ParcelCost.CostDeliveryToPoint > 0)
        {
            var result = _dbContext.Account.Where(w => w.BranchId == request.ParcelBranchFromId).Where(w => w.CurrencyId == request.ParcelCost.CurrencyId).FirstOrDefault();
            result.Balance = result.Balance + request.ParcelCost.CostDeliveryToPoint;
            accountHistory = new AccountHistory()
            {
                BranchAccountId = request.ParcelBranchFromId,
                JobType = true,
                Amount = request.ParcelCost.CostDeliveryToPoint,
                PayerId = request.RecepientId,
                ParcelId = ParcelId,
                CurrencyId = request.ParcelCost.CurrencyId
            };
        }

        if (request.ParcelCost.StatePickingUp && request.ParcelCost.CostPickingUp > 0)
        {
            var result = _dbContext.Account.Where(w => w.BranchId == request.ParcelBranchFromId).Where(w => w.CurrencyId == request.ParcelCost.CurrencyId).FirstOrDefault();
            result.Balance = result.Balance + request.ParcelCost.CostPickingUp;
            accountHistory = new AccountHistory()
            {
                BranchAccountId = request.ParcelBranchFromId,
                JobType = true,
                Amount = request.ParcelCost.CostPickingUp,
                PayerId = request.RecepientId,
                ParcelId = ParcelId,
                CurrencyId = request.ParcelCost.CurrencyId
            };
        }

        if (!string.IsNullOrWhiteSpace(request.SenderCourierId) || !string.IsNullOrEmpty(request.SenderCourierId))
        {
            parcelJob = new ParcelJob()
            {
                CourierId = request.SenderCourierId,
                PaymentState = false,
                JobType = "Забор",
                Cost = request.ParcelCost.CostPickingUp,
                ParcelId = ParcelId
            };
            await _dbContext.ParcelJob.AddAsync(parcelJob, cancellationToken);
        }

        if (!string.IsNullOrWhiteSpace(request.RecepientCourierId) || !string.IsNullOrEmpty(request.RecepientCourierId))
        {
            parcelJob = new ParcelJob()
            {
                CourierId = request.RecepientCourierId,
                PaymentState = false,
                JobType = "Доставка",
                Cost = request.ParcelCost.CostDeliveryToPoint,
                ParcelId = ParcelId
            };
            await _dbContext.ParcelJob.AddAsync(parcelJob, cancellationToken);
        }

        await _dbContext.AccountHistory.AddAsync(accountHistory, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return parcel.Id;
    }
}