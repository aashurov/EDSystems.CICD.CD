using MediatR;

namespace EDSystems.Application.Roles.Commands.CreateRole;

public class CreateRoleCommand : IRequest<string>
{
    public string Name { get; set; }
}