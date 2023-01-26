using MediatR;

namespace EDSystems.Application.EDSystems.Commands.Accounts.UpdateUserAccount;

public class UpdateUserAccountCommand : IRequest
{
    public int Id { get; set; }
    public string Number { get; set; }
    public string Name { get; set; }
    public decimal Balance { get; set; }
    public string UserId { get; set; }
    public int CurrencyId { get; set; }
}