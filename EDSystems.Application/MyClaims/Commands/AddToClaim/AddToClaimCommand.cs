using MediatR;

namespace EDSystems.Application.EDSystems.Commands.MyClaims.AddToClaim;

public class AddToClaimCommand : IRequest<Unit>
{
    public string Email { get; set; }
    public string ClaimType { get; set; }
    public string ClaimName { get; set; }
    public string ClaimValue { get; set; }
}