using MediatR;

namespace EDSystems.Application.EDSystems.Queries.AccountsHistory.GetAccountHistoryDetails;

public class GetAccountHistoryDetailsQuery : IRequest<AccountHistoryDetailsVm>
{
    public int Id { get; set; }
}