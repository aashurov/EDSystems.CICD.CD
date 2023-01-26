using MediatR;

namespace EDSystems.Application.EDSystems.Commands.Branches.DeleteBranch;

public class DeleteBranchCommand : IRequest
{
    public int Id { get; set; }
}