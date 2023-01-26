using MediatR;

namespace EDSystems.Application.EDSystems.Commands.Statuses.CreateStatus;

public class CreateStatusCommand : IRequest<int>
{
    public string Name { get; set; }
    public string Description { get; set; }
}