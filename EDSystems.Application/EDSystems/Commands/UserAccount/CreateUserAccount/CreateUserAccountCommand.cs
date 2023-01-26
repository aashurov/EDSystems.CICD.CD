using MediatR;

namespace EDSystems.Application.EDSystems.Commands.Accounts.CreateAccount;

public class CreateUserAccountCommand : IRequest<int>
{
    public string Number { get; set; }
    public string Name { get; set; }
    public decimal Balance { get; set; }
    public string UserId { get; set; }
    public int CurrencyId { get; set; }
}