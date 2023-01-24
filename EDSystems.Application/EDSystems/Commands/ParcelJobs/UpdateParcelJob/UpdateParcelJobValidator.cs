using FluentValidation;

namespace EDSystems.Application.EDSystems.Commands.ParcelJobs.UpdateParcelJob
{
    public class UpdateParcelJobCommandValidator : AbstractValidator<UpdateParcelJobCommand>
    {
        public UpdateParcelJobCommandValidator()
        {
            RuleFor(updateParcelJobCommand => updateParcelJobCommand.Id).GreaterThan(0);
        }
    }
}