using MediatR;

namespace EDSystems.Application.EDSystems.Queries.UserAccounts.GetUserAccountDetails;

public class GetUserAccountDetailsQuery : IRequest<UserAccountDetailsVm>
{
    public int Id { get; set; }
}