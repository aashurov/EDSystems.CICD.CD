using MediatR;
using System.Collections.Generic;

namespace EDSystems.Application.EDSystems.Commands.Accounts.DeleteUserAccounts;

public class DeleteUserAccountsCommand : IRequest<Unit>
{
    public IEnumerable<int> Id { get; set; }
}