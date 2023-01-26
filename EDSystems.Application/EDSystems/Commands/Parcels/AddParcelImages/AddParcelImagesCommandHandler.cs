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

namespace EDSystems.Application.EDSystems.Commands.Parcels.AddParcelImages;

public class AddParcelImagesCommandHandler : IRequestHandler<AddParcelImagesCommand>
{
    private readonly IEDSystemsDbContext _dbContext;
    private readonly IWebHostEnvironment _env;

    public AddParcelImagesCommandHandler(IEDSystemsDbContext dbContext, IWebHostEnvironment env) => (_dbContext, _env) = (dbContext, env);

    public async Task<Unit> Handle(AddParcelImagesCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Parcel.Include(e => e.ParcelImage).FirstOrDefaultAsync(e => e.Id == request.ParcelId, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Parcel), request.ParcelId);
        }
        var count = entity.ParcelImage.Count;
        int i = 0;
        if (count > 0)
        {
            i = count + 1;
        }
        else
            i = 1;
        foreach (var ImageByte in request.ImageBytes)
        {
            var index = ImageByte.IndexOf(',');
            //var base64stringWhiouSignature = ImageByte.Substring(index + 1);
            var base64stringWhiouSignature = ImageByte[(index + 1)..];

            index = ImageByte.IndexOf(';');

            //var base64Signature = ImageByte.Substring(0, index);
            var base64Signature = ImageByte[..index];
            index = base64Signature.IndexOf('/');
            //var extension = base64Signature.Substring(index + 1);
            var extension = base64Signature[(index + 1)..];

            byte[] bytes = Convert.FromBase64String(base64stringWhiouSignature);

            await System.IO.File.WriteAllBytesAsync(_env.WebRootPath + "\\MainImages\\" + entity.Code + "_" + i + "." + extension, bytes, CancellationToken.None);
            string imageName = entity.Code + "_" + i + "." + extension;

            var parcelImage = new ParcelImage
            {
                ImageBytes = ImageByte,
                ImageName = imageName
            };

            ICollection<ParcelImage> parcelColection = new Collection<ParcelImage>() { parcelImage };

            entity.ParcelImage.Add(parcelImage);

            await _dbContext.SaveChangesAsync(cancellationToken);
            i++;
        }
        return Unit.Value;
    }
}