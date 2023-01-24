using FluentValidation;

namespace EDSystems.Application.EDSystems.Commands.Branches.CreateBranch;

public class CreateBranchValidator : AbstractValidator<CreateBranchCommand>
{
    public CreateBranchValidator()
    {
        RuleFor(createBranchCommand => createBranchCommand.Name).NotEmpty().MaximumLength(250).NotEqual(string.Empty);
        RuleFor(createBranchCommand => createBranchCommand.Address).NotEmpty().MaximumLength(1024).NotEqual(string.Empty);
        RuleFor(createBranchCommand => createBranchCommand.Phone).NotEmpty().MaximumLength(13).WithErrorCode("404");
        RuleFor(createBranchCommand => createBranchCommand.City).NotEmpty().MaximumLength(50);
        RuleFor(createBranchCommand => createBranchCommand.Country).NotEmpty().MaximumLength(250).NotEqual(string.Empty);
        RuleFor(createBranchCommand => createBranchCommand.Code).NotEmpty().MaximumLength(20).NotEqual(string.Empty);
        RuleFor(createBranchCommand => createBranchCommand.Email).NotEmpty().MaximumLength(50);
    }
}