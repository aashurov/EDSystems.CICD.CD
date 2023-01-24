using MediatR;

namespace EDSystems.Application.EDSystems.Commands.Branches.UpdateBranch;

public class UpdateBranchCommand : IRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Country { get; set; }
    public string Code { get; set; }
    public string City { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
}