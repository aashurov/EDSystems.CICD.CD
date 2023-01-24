using AutoMapper;
using EDSystems.Application.Common.Mappings;
using EDSystems.Domain.Entities;
using System;

namespace EDSystems.Application.EDSystems.Queries.Plans.GetPlanDetails;

public class PlanDetailsVm : IMapWith<Plan>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Cost { get; set; }
    public string Description { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime? DateUpdated { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Plan, PlanDetailsVm>()
            .ForMember(planDetailsVm => planDetailsVm.Id, opt => opt.MapFrom(plan => plan.Id))
            .ForMember(planDetailsVm => planDetailsVm.Name, opt => opt.MapFrom(plan => plan.Name))
            .ForMember(planDetailsVm => planDetailsVm.Cost, opt => opt.MapFrom(plan => plan.Cost))
            .ForMember(planDetailsVm => planDetailsVm.Description, opt => opt.MapFrom(plan => plan.Description))
            .ForMember(planDetailsVm => planDetailsVm.DateCreated, opt => opt.MapFrom(plan => plan.DateCreated))
            .ForMember(planDetailsVm => planDetailsVm.DateUpdated, opt => opt.MapFrom(plan => plan.DateUpdated));
    }
}