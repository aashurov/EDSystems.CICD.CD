using MediatR;

namespace EDSystems.Application.EDSystems.Queries.Accounts.GetAccountDetails;

public class GetAccountDetailsQuery : IRequest<AccountDetailsVm>
{
    public int Id { get; set; }
}