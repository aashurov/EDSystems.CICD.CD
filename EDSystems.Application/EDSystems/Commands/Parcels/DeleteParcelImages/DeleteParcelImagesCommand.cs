using MediatR;
using System.Collections.Generic;

namespace EDSystems.Application.EDSystems.Commands.Parcels.DeleteParcelImages;

public class DeleteParcelImagesCommand : IRequest<Unit>
{
    public int ParcelId { get; set; }
    public IEnumerable<int> ParcelImageId { get; set; }
}