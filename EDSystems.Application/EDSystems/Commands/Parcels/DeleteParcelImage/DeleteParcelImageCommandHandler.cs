using EDSystems.Application.Common.Exceptions;
using EDSystems.Application.Interfaces;
using EDSystems.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace EDSystems.Application.EDSystems.Commands.Parcels.DeleteImageFromParcel;

public class DeleteParcelImageCommandHandler : IRequestHandler<DeleteParcelImageCommand, Unit>
{
    private readonly IEDSystemsDbContext _dbContext;
    private readonly IWebHostEnvironment _env;

    public DeleteParcelImageCommandHandler(IEDSystemsDbContext dbContext, IWebHostEnvironment env) => (_dbContext, _env) = (dbContext, env);

    public async Task<Unit> Handle(DeleteParcelImageCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Parcel.Include(o => o.ParcelImage).FirstOrDefaultAsync(parcel => parcel.Id == request.ParcelId, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Parcel), request.ParcelId);
        }
        var parcelImage = await _dbContext.ParcelImage.FindAsync(request.ParcelImageId);

        if (File.Exists(_env.WebRootPath + "\\MainImages\\" + parcelImage.ImageName))
        {
            File.Delete(_env.WebRootPath + "\\MainImages\\" + parcelImage.ImageName);
        }

        entity.ParcelImage.Remove(parcelImage);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}