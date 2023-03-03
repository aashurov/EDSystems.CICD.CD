using MediatR;

namespace EDSystems.Application.EDSystems.Commands.Parcels.AddParcelSound;

public class AddParcelSoundCommand : IRequest<Unit>
{
    public int ParcelId { get; set; }
    public string SoundBytes { get; set; }
}