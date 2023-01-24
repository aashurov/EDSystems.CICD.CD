using MediatR;

namespace EDSystems.Application.Users.Commands.AddToRole;

public class AddToRoleCommand : IRequest<string>
{
    public string RoleId { get; set; }
    public string UserId { get; set; }
}