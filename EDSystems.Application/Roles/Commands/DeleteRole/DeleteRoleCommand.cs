using MediatR;

namespace EDSystems.Application.Roles.Commands.DeleteRole;

public class DeleteRoleCommand : IRequest
{
    public string Id { get; set; }
}