using EDSystems.Application.Interfaces;
using EDSystems.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EDSystems.Application.EDSystems.Commands.Accounts.CreateAccount;

public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, int>
{
    private readonly IEDSystemsDbContext _dbContext;
    private readonly ICustomLoggingBehavoir _customLoggingBehavior;
    private static readonly string _ClassName = nameof(CreateAccountCommandHandler);

    public CreateAccountCommandHandler(IEDSystemsDbContext dbContext, ICustomLoggingBehavoir customLoggingBehavior) => (_dbContext, _customLoggingBehavior) = (dbContext, customLoggingBehavior);

    public async Task<int> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
    {
        var account = new Account
        {
            Name = request.Name,
            Number = request.Number,
            BranchId = request.BranchId,
            CurrencyId = request.CurrencyId
        };
        await _dbContext.Account.AddAsync(account, cancellationToken);
        var result = await _dbContext.SaveChangesAsync(cancellationToken);
        if (result > 0)
        {
            _customLoggingBehavior.WriteToFileSuccess(_ClassName, account);
        }
        return account.Id;
    }
}