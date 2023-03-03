using EDSystems.Application.Common.Exceptions;
using EDSystems.Application.Interfaces;
using EDSystems.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace EDSystems.Application.EDSystems.Commands.Parcels.DeleteParcel;

public class DeleteParcelCommandHandler : IRequestHandler<DeleteParcelCommand, Unit>
{
    private readonly IEDSystemsDbContext _dbContext;
    private IWebHostEnvironment _env;

    public DeleteParcelCommandHandler(IEDSystemsDbContext dbContext, IWebHostEnvironment env) => (_dbContext, _env) = (dbContext, env);

    public async Task<Unit> Handle(DeleteParcelCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Parcel.Include(e => e.ParcelImage).FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

        //var entity = await _dbContext.ParcelMain.FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Parcel), request.Id);
        }
        foreach (var file in entity.ParcelImage)
        {
            //await System.IO.File.WriteAllBytesAsync("wwwroot/" + Code + "_" + i + "." + extension, bytes);
            if (File.Exists(_env.WebRootPath + "\\MainImages\\" + file.ImageName))
            {
                File.Delete(_env.WebRootPath + "\\MainImages\\" + file.ImageName);
            }
        }
        _dbContext.Parcel.Remove(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}