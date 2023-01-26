using FluentValidation;

namespace EDSystems.Application.EDSystems.Commands.Branches.DeleteBranch;

public class DeleteBranchCommandValidator : AbstractValidator<DeleteBranchCommand>
{
    public DeleteBranchCommandValidator()
    {
        RuleFor(deleteBranchCommand => deleteBranchCommand.Id).GreaterThan(0);
    }
}