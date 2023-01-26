using MediatR;
using System.Collections.Generic;

namespace EDSystems.Application.EDSystems.Commands.Parcels.AddParcelSounds;

public class AddParcelSoundsCommand : IRequest
{
    public int ParcelId { get; set; }
    public IEnumerable<string> SoundBytes { get; set; }
}