using MediatR;
using System.Collections.Generic;

namespace EDSystems.Application.EDSystems.Commands.Parcels.AddParcelSounds;

public class AddParcelSoundsCommand : IRequest<Unit>
{
    public int ParcelId { get; set; }
    public IEnumerable<string> SoundBytes { get; set; }
}