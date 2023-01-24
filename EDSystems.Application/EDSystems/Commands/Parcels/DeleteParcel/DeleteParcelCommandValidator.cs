using EDSystems.Application.EDSystems.Commands.Branches.DeleteBranch;
using FluentValidation;

namespace EDSystems.Application.EDSystems.Commands.Parcels.DeleteParcel;

public class DeleteParcelCommandValidator : AbstractValidator<DeleteBranchCommand>
{
    public DeleteParcelCommandValidator()
    {
        RuleFor(deleteParcelCommand => deleteParcelCommand.Id).GreaterThan(0);
    }
}