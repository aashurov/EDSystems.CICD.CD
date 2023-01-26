using MediatR;

namespace EDSystems.Application.EDSystems.Queries.Parcels.GetParcelDetails;

public class GetParcelDetailsQuery : IRequest<ParcelDetailsVm>
{
    public int Id { get; set; }
}