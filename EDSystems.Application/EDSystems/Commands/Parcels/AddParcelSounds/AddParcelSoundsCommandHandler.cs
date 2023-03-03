using EDSystems.Application.Common.Exceptions;
using EDSystems.Application.Interfaces;
using EDSystems.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;

namespace EDSystems.Application.EDSystems.Commands.Parcels.AddParcelSounds;

public class AddParcelSoundsCommandHandler : IRequestHandler<AddParcelSoundsCommand, Unit>
{
    private readonly IEDSystemsDbContext _dbContext;
    private IWebHostEnvironment _env;

    public AddParcelSoundsCommandHandler(IEDSystemsDbContext dbContext, IWebHostEnvironment env) => (_dbContext, _env) = (dbContext, env);

    public async Task<Unit> Handle(AddParcelSoundsCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Parcel.Include(e => e.ParcelSound).FirstOrDefaultAsync(e => e.Id == request.ParcelId, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Parcel), request.ParcelId);
        }
        var count = entity.ParcelSound.Count;
        int i = 0;
        if (count > 0)
        {
            i = count + 1;
        }
        else
            i = 1;
        foreach (var SoundByte in request.SoundBytes)
        {
            var index = SoundByte.IndexOf(',');
            var base64stringWhiouSignature = SoundByte.Substring(index + 1);

            index = SoundByte.IndexOf(';');

            var base64Signature = SoundByte.Substring(0, index);
            index = base64Signature.IndexOf('/');
            var extension = base64Signature.Substring(index + 1);

            byte[] bytes = Convert.FromBase64String(base64stringWhiouSignature);

            await System.IO.File.WriteAllBytesAsync(_env.WebRootPath + "\\MainSounds\\" + entity.Code + "_" + i + "." + extension, bytes);
            string soundName = entity.Code + "_" + i + "." + extension;

            var parcelSound = new ParcelSound
            {
                SoundBytes = SoundByte,
                SoundName = soundName
            };

            ICollection<ParcelSound> parcelColection = new Collection<ParcelSound>();
            parcelColection.Add(parcelSound);

            entity.ParcelSound.Add(parcelSound);
            await _dbContext.SaveChangesAsync(cancellationToken);
            i++;
        }
        return Unit.Value;
    }
}