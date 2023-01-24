using MediatR;

namespace EDSystems.Application.EDSystems.Commands.MyClaims.AddToClaim;

public class AddToClaimCommand : IRequest
{
    public string Email { get; set; }
    public string ClaimName { get; set; }
    public string ClaimValue { get; set; }
}