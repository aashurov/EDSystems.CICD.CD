using MediatR;

namespace EDSystems.Application.EDSystems.Commands.Accounts.DeleteUserAccount;

public class DeleteUserAccountCommand : IRequest
{
    public int Id { get; set; }
}