using MediatR;

namespace EDSystems.Application.EDSystems.Commands.Parcels.DeleteParcelSound
{
    public class DeleteParcelSoundCommand : IRequest
    {
        public int ParcelId { get; set; }
        public int ParcelSoundId { get; set; }
    }
}