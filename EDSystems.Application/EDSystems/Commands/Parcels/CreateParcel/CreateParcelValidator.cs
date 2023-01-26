using FluentValidation;

namespace EDSystems.Application.EDSystems.Commands.Parcels.CreateParcel;

public class CreateParcelValidator : AbstractValidator<CreateParcelCommand>
{
    public CreateParcelValidator()
    {
        //RuleFor(createParcelCommand => createParcelCommand.Id).NotEmpty();
        //RuleFor(createParcelCommand => createParcelCommand.RecepientId).NotEmpty();
        //RuleFor(createParcelCommand => createParcelCommand.SenderId).NotEmpty();
        //RuleFor(createParcelCommand => createParcelCommand.ParcelPlanId).NotEmpty();
        //RuleFor(createParcelCommand => createParcelCommand.ParcelBranchFromId).NotEmpty();
        //RuleFor(createParcelCommand => createParcelCommand.ParcelBranchToId).NotEmpty();
        //RuleFor(createParcelCommand => createParcelCommand.ParcelCost.CostDeliveryToBranchUSD).GreaterThan(0);
    }
}