using MediatR;

namespace EDSystems.Application.EDSystems.Commands.Parcels.DeleteParcel;

public class DeleteParcelCommand : IRequest
{
    public int Id { get; set; }
}