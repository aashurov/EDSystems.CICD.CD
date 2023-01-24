using MediatR;
using System.Collections.Generic;

namespace EDSystems.Application.EDSystems.Commands.Parcels.UpdateParcelSounds;

public class UpdateParcelSoundsCommand : IRequest
{
    public int ParcelId { get; set; }
    public IEnumerable<string> SoundBytes { get; set; }
}