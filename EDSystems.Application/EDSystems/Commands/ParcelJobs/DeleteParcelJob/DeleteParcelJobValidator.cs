using FluentValidation;

namespace EDSystems.Application.EDSystems.Commands.ParcelJobs.DeleteParcelJob;

public class DeleteParcelJobCommandValidator : AbstractValidator<DeleteParcelJobCommand>
{
    public DeleteParcelJobCommandValidator()
    {
        RuleFor(deleteParcelJobCommand => deleteParcelJobCommand.Id).GreaterThan(0);
    }
}