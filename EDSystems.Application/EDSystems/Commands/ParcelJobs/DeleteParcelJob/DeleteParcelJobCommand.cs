using MediatR;

namespace EDSystems.Application.EDSystems.Commands.ParcelJobs.DeleteParcelJob;

public class DeleteParcelJobCommand : IRequest<Unit>
{
    public int Id { get; set; }
}