using FluentValidation;

namespace EDSystems.Application.EDSystems.Commands.ParcelJobs.CreateParcelJob;

public class CreateParcelJobValidator : AbstractValidator<CreateParcelJobCommand>
{
    public CreateParcelJobValidator()
    {
    }
}