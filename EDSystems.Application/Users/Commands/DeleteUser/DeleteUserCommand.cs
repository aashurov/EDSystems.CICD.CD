using MediatR;

namespace EDSystems.Application.Users.Commands.DeleteUser;

public class DeleteUserCommand : IRequest
{
    public string Id { get; set; }
}