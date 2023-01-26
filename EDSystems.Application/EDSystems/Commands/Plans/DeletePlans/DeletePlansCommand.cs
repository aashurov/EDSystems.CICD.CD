using MediatR;
using System.Collections.Generic;

namespace EDSystems.Application.EDSystems.Commands.Plans.DeletePlans;

public class DeletePlansCommand : IRequest
{
    public IEnumerable<int> Id { get; set; }
}