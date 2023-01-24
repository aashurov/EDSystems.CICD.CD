using MediatR;

namespace EDSystems.Application.EDSystems.Queries.ParcelJobs.GetParcelJobDetails;

public class GetParcelJobDetailsQuery : IRequest<ParcelJobDetailsVm>
{
    public int Id { get; set; }
}