using MediatR;

namespace EDSystems.Application.Users.Commands.UpdatePassword;

public class UpdatePasswordCommand : IRequest<Unit>
{
    public string UserId { get; set; }
    public string PasswordHash { get; set; }
}