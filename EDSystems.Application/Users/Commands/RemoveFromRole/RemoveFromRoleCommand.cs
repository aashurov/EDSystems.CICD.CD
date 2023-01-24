using MediatR;

namespace EDSystems.Application.Users.Commands.DeleteFromRole
{
    public class DeleteFromRoleCommand : IRequest
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string RoleId { get; set; }
    }
}