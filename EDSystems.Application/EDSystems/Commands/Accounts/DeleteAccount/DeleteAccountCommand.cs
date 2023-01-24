using MediatR;

namespace EDSystems.Application.EDSystems.Commands.Accounts.DeleteAccount;

public class DeleteAccountCommand : IRequest
{
    public int Id { get; set; }
}