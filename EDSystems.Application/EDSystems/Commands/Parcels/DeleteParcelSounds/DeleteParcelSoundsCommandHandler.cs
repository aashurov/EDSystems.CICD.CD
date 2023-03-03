using EDSystems.Application.Common.Exceptions;
using EDSystems.Application.Interfaces;
using EDSystems.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace EDSystems.Application.EDSystems.Commands.Parcels.DeleteParcelSounds;

public class DeleteParcelSoundsCommandHandler : IRequestHandler<DeleteParcelSoundsCommand, Unit>
{
    private readonly IEDSystemsDbContext _dbContext;
    private readonly IWebHostEnvironment _env;

    public DeleteParcelSoundsCommandHandler(IEDSystemsDbContext dbContext, IWebHostEnvironment env) => (_dbContext, _env) = (dbContext, env);

    public async Task<Unit> Handle(DeleteParcelSoundsCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Parcel.Include(o => o.ParcelSound).FirstOrDefaultAsync(parcel => parcel.Id == request.ParcelId, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Parcel), request.ParcelId);
        }
        foreach (var item in request.ParcelSoundId)
        {
            var parcelSound = await _dbContext.ParcelSound.FindAsync(item);

            if (File.Exists(_env.WebRootPath + "\\MainSounds\\" + parcelSound.SoundName))
            {
                File.Delete(_env.WebRootPath + "\\MainSounds\\" + parcelSound.SoundName);
            }

            entity.ParcelSound.Remove(parcelSound);

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
        return Unit.Value;
    }
}