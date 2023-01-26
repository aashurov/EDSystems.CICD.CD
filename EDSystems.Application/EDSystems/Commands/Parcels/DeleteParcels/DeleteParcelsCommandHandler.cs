using EDSystems.Application.Common.Exceptions;
using EDSystems.Application.Interfaces;
using EDSystems.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EDSystems.Application.EDSystems.Commands.Parcels.DeleteParcels;

public class DeleteParcelsCommandHandler : IRequestHandler<DeleteParcelsCommand>
{
    private readonly IEDSystemsDbContext _dbContext;

    public DeleteParcelsCommandHandler(IEDSystemsDbContext dbContext) => _dbContext = dbContext;

    public async Task<Unit> Handle(DeleteParcelsCommand request, CancellationToken cancellationToken)
    {
        foreach (var item in request.Id)
        {
            var entity = await _dbContext.Parcel.FindAsync(new object[] { item }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Parcel), request.Id);
            }
            _dbContext.Parcel.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
        return Unit.Value;
    }
}