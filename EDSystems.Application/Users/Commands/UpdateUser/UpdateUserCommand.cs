using MediatR;

namespace EDSystems.Application.Users.Commands.UpdateUser;

public class UpdateUserCommand : IRequest
{
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
}