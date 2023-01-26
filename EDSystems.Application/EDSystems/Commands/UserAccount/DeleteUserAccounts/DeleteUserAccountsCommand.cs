using MediatR;
using System.Collections.Generic;

namespace EDSystems.Application.EDSystems.Commands.Accounts.DeleteUserAccounts;

public class DeleteUserAccountsCommand : IRequest
{
    public IEnumerable<int> Id { get; set; }
}