using MediatR;
using System;

namespace EDSystems.Application.EDSystems.Commands.Statuses.UpdateStatus;

public class UpdateStatusCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime? DateUpdated { get; set; } = DateTime.Now;
}