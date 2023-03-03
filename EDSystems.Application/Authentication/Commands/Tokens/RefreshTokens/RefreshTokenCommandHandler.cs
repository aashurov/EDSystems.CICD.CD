using EDSystems.Application.Interfaces;
using EDSystems.Domain.Entities.UserEntities;
using MediatR;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace EDSystems.Application.Authentication.Commands.Tokens.RefreshTokens;

public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, Unit>
{
    private readonly IEDSystemsDbContext _dbContext;
    private readonly ICustomLoggingBehavoir _customLoggingBehavior;

    public RefreshTokenCommandHandler(IEDSystemsDbContext dbContext, ICustomLoggingBehavoir customLoggingBehavior) => (_dbContext, _customLoggingBehavior) = (dbContext, customLoggingBehavior);

    public async Task<Unit> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        var token = new RefreshToken
        {
            Token = request.Token,
            UserId = request.UserId,
            JwtId = request.JwtId,
            IsUsed = request.IsUsed,
            IsRevoked = request.IsRevoked
        };

        await _dbContext.RefreshToken.AddAsync(token, cancellationToken);
        int result = await _dbContext.SaveChangesAsync(cancellationToken);
        string className = MethodBase.GetCurrentMethod().DeclaringType.Name;

        if (result > 0)
        {
            _customLoggingBehavior.WriteToFileSuccess(className, token);
        }
        return Unit.Value;
    }
}