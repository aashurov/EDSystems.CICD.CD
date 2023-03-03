using EDSystems.Application.Common.Exceptions;
using EDSystems.Application.Interfaces;
using EDSystems.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EDSystems.Application.EDSystems.Commands.Parcels.UpdateParcelImages;

public class UpdateParcelImagesCommandHandler : IRequestHandler<UpdateParcelImagesCommand, Unit>
{
    private readonly IEDSystemsDbContext _dbContext;
    private IWebHostEnvironment _env;

    public UpdateParcelImagesCommandHandler(IEDSystemsDbContext dbContext, IWebHostEnvironment env) => (_dbContext, _env) = (dbContext, env);

    public async Task<Unit> Handle(UpdateParcelImagesCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Parcel.Include(e => e.ParcelImage).FirstOrDefaultAsync(e => e.Id == request.ParcelId, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Parcel), request.ParcelId);
        }
        var count = entity.ParcelImage.Count();
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
            var base64stringWhiouSignature = ImageByte.Substring(index + 1);

            index = ImageByte.IndexOf(';');

            var base64Signature = ImageByte.Substring(0, index);
            index = base64Signature.IndexOf('/');
            var extension = base64Signature.Substring(index + 1);

            byte[] bytes = Convert.FromBase64String(base64stringWhiouSignature);

            await System.IO.File.WriteAllBytesAsync(_env.WebRootPath + "\\MainImages\\" + entity.Code + "_" + i + "." + extension, bytes);
            string imageName = entity.Code + "_" + i + "." + extension;

            var parcelImage = new ParcelImage
            {
                ImageBytes = ImageByte,
                ImageName = imageName
            };

            ICollection<ParcelImage> parcelColection = new Collection<ParcelImage>();
            parcelColection.Add(parcelImage);

            entity.ParcelImage = parcelColection;
            await _dbContext.SaveChangesAsync(cancellationToken);
            i++;
        }
        return Unit.Value;
    }
}