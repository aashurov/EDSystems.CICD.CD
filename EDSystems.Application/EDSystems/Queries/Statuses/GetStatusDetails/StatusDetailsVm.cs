using AutoMapper;
using EDSystems.Application.Common.Mappings;
using EDSystems.Domain.Entities;
using System;

namespace EDSystems.Application.EDSystems.Queries.Statuses.GetStatusDetails;

public class StatusDetailsVm : IMapWith<Status>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime? DateUpdated { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Status, StatusDetailsVm>()
            .ForMember(statusDetailsVm => statusDetailsVm.Id, opt => opt.MapFrom(status => status.Id))
            .ForMember(statusDetailsVm => statusDetailsVm.Name, opt => opt.MapFrom(status => status.Name))
            .ForMember(statusDetailsVm => statusDetailsVm.Description, opt => opt.MapFrom(status => status.Description))
            .ForMember(statusDetailsVm => statusDetailsVm.DateCreated, opt => opt.MapFrom(status => status.DateCreated))
            .ForMember(statusDetailsVm => statusDetailsVm.DateUpdated, opt => opt.MapFrom(status => status.DateUpdated));
    }
}