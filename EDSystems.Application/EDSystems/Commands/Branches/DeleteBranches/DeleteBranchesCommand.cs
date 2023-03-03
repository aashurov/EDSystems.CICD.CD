using MediatR;
using System.Collections.Generic;

namespace EDSystems.Application.EDSystems.Commands.Branches.DeleteBranches;

public class DeleteBranchesCommand : IRequest<Unit>
{
    public IEnumerable<int> Id { get; set; }
}