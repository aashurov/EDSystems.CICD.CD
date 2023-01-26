using EDSystems.Application.Interfaces;
using EDSystems.Domain.Entities.UserEntities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace EDSystems.Application.EDSystems.Commands.MyClaims.AddToClaim;

public class AddToClaimCommandHandler : IRequestHandler<AddToClaimCommand>
{
    private readonly ICustomLoggingBehavoir _customLoggingBehavior;
    private readonly UserManager<User> _userManager;
    private static readonly string _ClassName = nameof(AddToClaimCommandHandler);

    public AddToClaimCommandHandler(ICustomLoggingBehavoir customLoggingBehavior, UserManager<User> userManager) => (_customLoggingBehavior, _userManager) = (customLoggingBehavior, userManager);

    public async Task<Unit> Handle(AddToClaimCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);
        var newClaim = new Claim(request.Email, request.ClaimName, request.ClaimValue);
        await _userManager.AddClaimAsync(user, newClaim);
        return Unit.Value;
    }
}