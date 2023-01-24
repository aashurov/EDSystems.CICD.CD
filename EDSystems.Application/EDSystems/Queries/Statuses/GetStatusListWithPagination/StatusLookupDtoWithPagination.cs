using AutoMapper;
using EDSystems.Application.Common.Mappings;
using EDSystems.Domain.Entities;
using System;

namespace EDSystems.Application.EDSystems.Queries.Statuses.GetStatusListWithPagination;

public class StatusLookupDtoWithPagination : IMapWith<Status>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime? DateUpdated { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Status, StatusLookupDtoWithPagination>()
            .ForMember(statusLookupDto => statusLookupDto.Id, opt => opt.MapFrom(status => status.Id))
            .ForMember(statusLookupDto => statusLookupDto.Name, opt => opt.MapFrom(status => status.Name))
            .ForMember(statusLookupDto => statusLookupDto.Description, opt => opt.MapFrom(status => status.Description))
            .ForMember(statusLookupDto => statusLookupDto.DateCreated, opt => opt.MapFrom(status => status.DateCreated))
            .ForMember(statusLookupDto => statusLookupDto.DateUpdated, opt => opt.MapFrom(status => status.DateUpdated));
    }
}