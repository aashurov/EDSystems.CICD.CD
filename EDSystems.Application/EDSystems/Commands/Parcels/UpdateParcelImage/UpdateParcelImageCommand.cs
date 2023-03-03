using MediatR;

namespace EDSystems.Application.EDSystems.Commands.Parcels.UpdateParcelImage;

public class UpdateParcelImageCommand : IRequest<Unit>
{
    public int ParcelId { get; set; }
    public string ImageBytes { get; set; }
}