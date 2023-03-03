using MediatR;

namespace EDSystems.Application.EDSystems.Commands.Plans.UpdatePlan;

public class UpdatePlanCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Cost { get; set; }
    public string Description { get; set; }
}