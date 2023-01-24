using MediatR;

namespace EDSystems.Application.EDSystems.Queries.Plans.GetPlanDetails;

public class GetPlanDetailsQuery : IRequest<PlanDetailsVm>
{
    public int Id { get; set; }
}