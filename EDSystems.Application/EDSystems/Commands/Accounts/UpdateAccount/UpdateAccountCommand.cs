using MediatR;

namespace EDSystems.Application.EDSystems.Commands.Accounts.UpdateAccount;

public class UpdateAccountCommand : IRequest
{
    public int Id { get; set; }
    public string Number { get; set; }
    public string Name { get; set; }
    public decimal Balance { get; set; }
    public int BranchId { get; set; }
    public int CurrencyId { get; set; }
}