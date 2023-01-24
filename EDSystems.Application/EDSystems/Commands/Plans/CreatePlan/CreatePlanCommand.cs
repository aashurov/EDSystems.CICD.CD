using MediatR;

namespace EDSystems.Application.EDSystems.Commands.Plans.CreatePlan;

public class CreatePlanCommand : IRequest<int>
{
    public string Name { get; set; }
    public decimal Cost { get; set; }
    public string Description { get; set; }
}