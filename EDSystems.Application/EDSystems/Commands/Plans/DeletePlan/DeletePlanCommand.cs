using MediatR;

namespace EDSystems.Application.EDSystems.Commands.Plans.DeletePlan;

public class DeletePlanCommand : IRequest<Unit>
{
    public int Id { get; set; }
}