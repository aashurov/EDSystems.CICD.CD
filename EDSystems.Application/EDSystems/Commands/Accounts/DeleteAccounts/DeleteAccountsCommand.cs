using MediatR;
using System.Collections.Generic;

namespace EDSystems.Application.EDSystems.Commands.Accounts.DeleteAccounts;

public class DeleteAccountsCommand : IRequest<Unit>
{
    public IEnumerable<int> Id { get; set; }
}