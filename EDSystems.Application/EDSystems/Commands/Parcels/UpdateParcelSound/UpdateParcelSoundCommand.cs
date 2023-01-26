using MediatR;

namespace EDSystems.Application.EDSystems.Commands.Parcels.UpdateParcelSound;

public class UpdateParcelSoundCommand : IRequest
{
    public int ParcelId { get; set; }
    public string SoundBytes { get; set; }
}