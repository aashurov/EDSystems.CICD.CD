using MediatR;

namespace EDSystems.Application.EDSystems.Commands.Accounts.DeleteUserAccount;

public class DeleteUserAccountCommand : IRequest<Unit>
{
    public int Id { get; set; }
}