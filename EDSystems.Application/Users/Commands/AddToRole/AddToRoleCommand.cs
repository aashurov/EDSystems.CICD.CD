using MediatR;

namespace EDSystems.Application.Users.Commands.AddToRole;

public class AddToRoleCommand : IRequest<int>
{
    public int RoleId { get; set; }
    public int UserId { get; set; }
}