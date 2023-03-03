using MediatR;

namespace EDSystems.Application.EDSystems.Commands.Parcels.DeleteImageFromParcel;

public class DeleteParcelImageCommand : IRequest<Unit>
{
    public int ParcelId { get; set; }
    public int ParcelImageId { get; set; }
}