using MediatR;

namespace EDSystems.Application.EDSystems.Commands.Statuses.DeleteStatus;

public class DeleteStatusCommand : IRequest
{
    public int Id { get; set; }
}