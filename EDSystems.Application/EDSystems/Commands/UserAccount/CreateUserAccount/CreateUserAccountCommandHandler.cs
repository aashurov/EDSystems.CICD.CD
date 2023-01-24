using EDSystems.Application.Interfaces;
using EDSystems.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EDSystems.Application.EDSystems.Commands.Accounts.CreateAccount;

public class CreateUserAccountCommandHandler : IRequestHandler<CreateUserAccountCommand, int>
{
    private readonly IEDSystemsDbContext _dbContext;
    private readonly ICustomLoggingBehavoir _customLoggingBehavior;
    private static readonly string _ClassName = nameof(CreateUserAccountCommandHandler);

    public CreateUserAccountCommandHandler(IEDSystemsDbContext dbContext, ICustomLoggingBehavoir customLoggingBehavior) => (_dbContext, _customLoggingBehavior) = (dbContext, customLoggingBehavior);

    public async Task<int> Handle(CreateUserAccountCommand request, CancellationToken cancellationToken)
    {
        var userAccount = new UserAccount
        {
            Name = request.Name,
            Number = request.Number,
            UserId = request.UserId,
            CurrencyId = request.CurrencyId
        };
        await _dbContext.UserAccount.AddAsync(userAccount, cancellationToken);
        var result = await _dbContext.SaveChangesAsync(cancellationToken);
        if (result > 0)
        {
            _customLoggingBehavior.WriteToFileSuccess(_ClassName, userAccount);
        }
        return userAccount.Id;
    }
}