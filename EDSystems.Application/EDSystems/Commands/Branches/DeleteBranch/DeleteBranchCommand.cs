using MediatR;

namespace EDSystems.Application.EDSystems.Commands.Branches.DeleteBranch;

public class DeleteBranchCommand : IRequest<Unit>
{
    public int Id { get; set; }
}