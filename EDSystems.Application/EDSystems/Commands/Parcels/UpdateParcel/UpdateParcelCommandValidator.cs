using EDSystems.Application.EDSystems.Commands.Parcels.CreateParcel;
using FluentValidation;

namespace EDSystems.Application.EDSystems.Commands.Parcels.UpdateParcel;

public class UpdateParcelCommandValidator : AbstractValidator<CreateParcelCommand>
{
    public UpdateParcelCommandValidator()
    {
        //RuleFor(updateParcelCommand => updateParcelCommand.Id).NotEmpty();
        RuleFor(updateParcelCommand => updateParcelCommand.RecepientId).NotEmpty();
        RuleFor(updateParcelCommand => updateParcelCommand.SenderId).NotEmpty();
        RuleFor(updateParcelCommand => updateParcelCommand.ParcelPlanId).NotEmpty();
        RuleFor(updateParcelCommand => updateParcelCommand.ParcelBranchFromId).NotEmpty();
        RuleFor(updateParcelCommand => updateParcelCommand.ParcelBranchToId).NotEmpty();
        RuleFor(updateParcelCommand => updateParcelCommand.ParcelCost.CostDeliveryToBranch).NotEmpty();
    }
}