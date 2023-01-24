using MediatR;

namespace EDSystems.Application.EDSystems.Commands.Parcels.UpdateParcelImage;

public class UpdateParcelImageCommand : IRequest
{
    public int ParcelId { get; set; }
    public string ImageBytes { get; set; }
}