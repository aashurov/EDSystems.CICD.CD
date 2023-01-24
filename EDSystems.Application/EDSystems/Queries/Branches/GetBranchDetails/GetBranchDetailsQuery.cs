using MediatR;

namespace EDSystems.Application.EDSystems.Queries.Branches.GetBranchDetails;

public class GetBranchDetailsQuery : IRequest<BranchDetailsVm>
{
    public int Id { get; set; }
}