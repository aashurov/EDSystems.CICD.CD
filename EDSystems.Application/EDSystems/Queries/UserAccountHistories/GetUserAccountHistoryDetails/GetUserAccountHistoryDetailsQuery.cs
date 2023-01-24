using MediatR;

namespace EDSystems.Application.EDSystems.Queries.UserAccountHistories.GetUserAccountHistoryDetails;

public class GetUserAccountHistoryDetailsQuery : IRequest<UserAccountHistoryDetailsVm>
{
    public int Id { get; set; }
}