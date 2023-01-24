using MediatR;

namespace EDSystems.Application.EDSystems.Queries.Statuses.GetStatusDetails;

public class GetStatusDetailsQuery : IRequest<StatusDetailsVm>
{
    public int Id { get; set; }
}