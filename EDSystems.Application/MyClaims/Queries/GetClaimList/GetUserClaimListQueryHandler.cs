using AutoMapper;
using EDSystems.Domain.Entities.UserEntities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace EDSystems.Application.Claims.Queries.GetClaimList;

public class GetUserClaimListQueryHandler : IRequestHandler<GetUserClaimListQuery, UserClaimListVm>
{
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;
    private readonly ILogger<GetUserClaimListQueryHandler> _logger;

    public GetUserClaimListQueryHandler(UserManager<User> userManager, IMapper mapper, ILogger<GetUserClaimListQueryHandler> logger) => (_userManager, _mapper, _logger) = (userManager, mapper, logger);

    public async Task<UserClaimListVm> Handle(GetUserClaimListQuery request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user == null)
        {
            _logger.LogInformation($"The User with the {request.Email} does not exist");

            return null;
        }
        var userClaims = await _userManager.GetClaimsAsync(user);
        return new UserClaimListVm { Claim = userClaims };
    }
}