using EDSystems.Application.Common.Exceptions;
using EDSystems.Application.Interfaces;
using EDSystems.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace EDSystems.Application.EDSystems.Commands.Accounts.UpdateAccount;

public class UpdateAccountCommandHandler : IRequestHandler<UpdateAccountCommand, Unit>
{
    private readonly IEDSystemsDbContext _dbContext;
    private readonly ICustomLoggingBehavoir _customLoggingBehavior;
    private static readonly string _ClassName = nameof(UpdateAccountCommandHandler);

    public UpdateAccountCommandHandler(IEDSystemsDbContext dbContext, ICustomLoggingBehavoir customLoggingBehavior) => (_dbContext, _customLoggingBehavior) = (dbContext, customLoggingBehavior);

    public async Task<Unit> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Account.FirstOrDefaultAsync(account => account.Id == request.Id, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Account), request.Id);
        }

        entity.Name = request.Name;
        entity.Number = request.Number;
        entity.Balance = request.Balance;
        entity.BranchId = request.BranchId;
        entity.CurrencyId = request.CurrencyId;

        var result = await _dbContext.SaveChangesAsync(cancellationToken);
        if (result > 0)
        {
            _customLoggingBehavior.WriteToFileSuccess(_ClassName, entity);
        }
        return Unit.Value;
    }
}