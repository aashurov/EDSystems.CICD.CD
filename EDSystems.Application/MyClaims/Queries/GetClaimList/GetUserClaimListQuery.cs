using MediatR;

namespace EDSystems.Application.Claims.Queries.GetClaimList;

public class GetUserClaimListQuery : IRequest<UserClaimListVm>
{
    public string Id { get; set; }
    public string Email { get; set; }
}