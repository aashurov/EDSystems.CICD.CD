using MediatR;

namespace EDSystems.Application.EDSystems.Commands.Statuses.DeleteStatus;

public class DeleteStatusCommand : IRequest<Unit>
{
    public int Id { get; set; }
}