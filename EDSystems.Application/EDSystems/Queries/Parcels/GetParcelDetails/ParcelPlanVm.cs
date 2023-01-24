using AutoMapper;
using EDSystems.Application.Common.Mappings;
using EDSystems.Domain.Entities;

namespace EDSystems.Application.EDSystems.Queries.Parcels.GetParcelDetails;

public class ParcelPlanVm : IMapWith<Plan>
{
    public string Name { get; set; }
    public decimal Cost { get; set; }
    public string Description { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Plan, ParcelPlanVm>()
            .ForMember(parcelPlanVm => parcelPlanVm.Name, opt => opt.MapFrom(plan => plan.Name))
            .ForMember(parcelPlanVm => parcelPlanVm.Cost, opt => opt.MapFrom(plan => plan.Cost))
            .ForMember(parcelPlanVm => parcelPlanVm.Description, opt => opt.MapFrom(plan => plan.Description));
    }
}