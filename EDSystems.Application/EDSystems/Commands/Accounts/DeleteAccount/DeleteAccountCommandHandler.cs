using EDSystems.Application.Common.Exceptions;
using EDSystems.Application.Interfaces;
using EDSystems.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EDSystems.Application.EDSystems.Commands.Accounts.DeleteAccount;

public class DeleteAccountCommandHandler : IRequestHandler<DeleteAccountCommand, Unit>
{
    private readonly IEDSystemsDbContext _dbContext;
    private readonly ICustomLoggingBehavoir _customLoggingBehavior;
    private static readonly string _ClassName = nameof(DeleteAccountCommandHandler);

    public DeleteAccountCommandHandler(IEDSystemsDbContext dbContext, ICustomLoggingBehavoir customLoggingBehavior) => (_dbContext, _customLoggingBehavior) = (dbContext, customLoggingBehavior);

    public async Task<Unit> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Account.FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Account), request.Id);
        }
        _dbContext.Account.Remove(entity);
        var result = await _dbContext.SaveChangesAsync(cancellationToken);

        if (result > 0)
        {
            _customLoggingBehavior.WriteToFileSuccess(_ClassName, entity);
        }
        return Unit.Value;
    }
}