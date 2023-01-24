using MediatR;

namespace EDSystems.Application.EDSystems.Commands.Parcels.AddParcelImage;

public class AddParcelImageCommand : IRequest
{
    public int ParcelId { get; set; }
    public string ImageBytes { get; set; }
}