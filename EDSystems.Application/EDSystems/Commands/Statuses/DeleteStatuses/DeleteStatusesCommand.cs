using MediatR;
using System.Collections.Generic;

namespace EDSystems.Application.EDSystems.Commands.Statuses.DeleteStatuses;

public class DeleteStatusesCommand : IRequest<Unit>
{
    public IEnumerable<int> Id { get; set; }
}