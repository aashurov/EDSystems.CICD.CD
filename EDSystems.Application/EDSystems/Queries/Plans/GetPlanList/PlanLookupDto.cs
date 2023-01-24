using AutoMapper;
using EDSystems.Application.Common.Mappings;
using EDSystems.Domain.Entities;
using System;

namespace EDSystems.Application.EDSystems.Queries.Plans.GetPlanList;

public class PlanLookupDto : IMapWith<Plan>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Cost { get; set; }
    public string Description { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime? DateUpdated { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Plan, PlanLookupDto>()
            .ForMember(parcelLookupWithPaginationDto => parcelLookupWithPaginationDto.Id, opt => opt.MapFrom(plan => plan.Id))
            .ForMember(parcelLookupWithPaginationDto => parcelLookupWithPaginationDto.Name, opt => opt.MapFrom(plan => plan.Name))
            .ForMember(parcelLookupWithPaginationDto => parcelLookupWithPaginationDto.Cost, opt => opt.MapFrom(plan => plan.Cost))
            .ForMember(parcelLookupWithPaginationDto => parcelLookupWithPaginationDto.Description, opt => opt.MapFrom(plan => plan.Description))
            .ForMember(parcelLookupWithPaginationDto => parcelLookupWithPaginationDto.DateCreated, opt => opt.MapFrom(plan => plan.DateCreated))
            .ForMember(parcelLookupWithPaginationDto => parcelLookupWithPaginationDto.DateUpdated, opt => opt.MapFrom(plan => plan.DateUpdated));
    }
}