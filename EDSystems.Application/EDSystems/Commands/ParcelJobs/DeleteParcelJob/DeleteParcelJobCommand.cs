using MediatR;

namespace EDSystems.Application.EDSystems.Commands.ParcelJobs.DeleteParcelJob;

public class DeleteParcelJobCommand : IRequest
{
    public int Id { get; set; }
}