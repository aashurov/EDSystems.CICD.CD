using MediatR;

namespace EDSystems.Application.Users.Commands.DeleteUser;

public class DeleteUserCommand : IRequest<Unit>
{
    public string Id { get; set; }
}