using MediatR;

namespace EDSystems.Application.Roles.Commands.CreateRole;

public class CreateRoleCommand : IRequest<int>
{
    public string Name { get; set; }
}