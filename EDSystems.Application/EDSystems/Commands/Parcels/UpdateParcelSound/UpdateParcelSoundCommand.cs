using MediatR;

namespace EDSystems.Application.EDSystems.Commands.Parcels.UpdateParcelSound;

public class UpdateParcelSoundCommand : IRequest<Unit>
{
    public int ParcelId { get; set; }
    public string SoundBytes { get; set; }
}