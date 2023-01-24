using EDSystems.Application.Common.Exceptions;
using EDSystems.Application.Interfaces;
using EDSystems.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace EDSystems.Application.EDSystems.Commands.Accounts.UpdateUserAccount;

public class UpdateUserAccountCommandHandler : IRequestHandler<UpdateUserAccountCommand>
{
    private readonly IEDSystemsDbContext _dbContext;
    private readonly ICustomLoggingBehavoir _customLoggingBehavior;
    private static readonly string _ClassName = nameof(UpdateUserAccountCommandHandler);

    public UpdateUserAccountCommandHandler(IEDSystemsDbContext dbContext, ICustomLoggingBehavoir customLoggingBehavior) => (_dbContext, _customLoggingBehavior) = (dbContext, customLoggingBehavior);

    public async Task<Unit> Handle(UpdateUserAccountCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.UserAccount.FirstOrDefaultAsync(account => account.Id == request.Id, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(UserAccount), request.Id);
        }

        entity.Name = request.Name;
        entity.Number = request.Number;
        entity.Balance = request.Balance;
        entity.UserId = request.UserId;
        entity.CurrencyId = request.CurrencyId;

        var result = await _dbContext.SaveChangesAsync(cancellationToken);
        if (result > 0)
        {
            _customLoggingBehavior.WriteToFileSuccess(_ClassName, entity);
        }
        return Unit.Value;
    }
}