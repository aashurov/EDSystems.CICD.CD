using FluentValidation;

namespace EDSystems.Application.EDSystems.Commands.Branches.UpdateBranch;

public class UpdateBranchCommandValidator : AbstractValidator<UpdateBranchCommand>
{
    public UpdateBranchCommandValidator()
    {
        RuleFor(updateBranchCommand => updateBranchCommand.Id).GreaterThan(0);
        RuleFor(updateBranchCommand => updateBranchCommand.Name).NotEmpty().MaximumLength(250);
    }
}