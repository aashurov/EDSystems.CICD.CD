using MediatR;
using System.Collections.Generic;

namespace EDSystems.Application.EDSystems.Commands.Accounts.DeleteAccounts;

public class DeleteAccountsCommand : IRequest
{
    public IEnumerable<int> Id { get; set; }
}