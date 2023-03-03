using MediatR;

namespace EDSystems.Application.Users.Commands.UpdateUserRole;

public class UpdateUserRoleCommand : IRequest<Unit>
{
    public string Id { get; set; }
    public string UserId { get; set; }
    public string NewRoleId { get; set; }
    public string OldRoleId { get; set; }
}