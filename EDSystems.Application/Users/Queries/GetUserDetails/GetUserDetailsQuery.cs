using MediatR;

namespace EDSystems.Application.Users.Queries.GetUserDetails;

public class GetUserDetailsQuery : IRequest<UserDetailsVm>
{
    public int Id { get; set; }
}