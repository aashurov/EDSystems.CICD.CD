using MediatR;
using System.Collections.Generic;

namespace EDSystems.Application.EDSystems.Commands.Parcels.UpdateParcelImages;

public class UpdateParcelImagesCommand : IRequest
{
    public int ParcelId { get; set; }
    public IEnumerable<string> ImageBytes { get; set; }
}