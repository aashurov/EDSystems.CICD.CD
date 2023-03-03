using MediatR;
using System.Collections.Generic;

namespace EDSystems.Application.EDSystems.Commands.Parcels.DeleteParcelSounds;

public class DeleteParcelSoundsCommand : IRequest<Unit>
{
    public int ParcelId { get; set; }
    public IEnumerable<int> ParcelSoundId { get; set; }
}