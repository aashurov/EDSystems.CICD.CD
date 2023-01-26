using EDSystems.Application.Common.Exceptions;
using EDSystems.Application.Interfaces;
using EDSystems.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace EDSystems.Application.EDSystems.Commands.Parcels.DeleteParcelSound;

public class DeleteParcelSoundCommandHandler : IRequestHandler<DeleteParcelSoundCommand>
{
    private readonly IEDSystemsDbContext _dbContext;
    private readonly IWebHostEnvironment _env;

    public DeleteParcelSoundCommandHandler(IEDSystemsDbContext dbContext, IWebHostEnvironment env) => (_dbContext, _env) = (dbContext, env);

    public async Task<Unit> Handle(DeleteParcelSoundCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Parcel.Include(o => o.ParcelSound).FirstOrDefaultAsync(parcel => parcel.Id == request.ParcelId, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Parcel), request.ParcelId);
        }
        var parcelSound = await _dbContext.ParcelSound.FindAsync(request.ParcelSoundId);
        if (parcelSound == null)
        {
            throw new NotFoundException(nameof(ParcelSound), request.ParcelSoundId);
        }

        if (File.Exists(_env.WebRootPath + "\\MainSounds\\" + parcelSound.SoundName))
        {
            File.Delete(_env.WebRootPath + "\\MainSounds\\" + parcelSound.SoundName);
        }

        entity.ParcelSound.Remove(parcelSound);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}