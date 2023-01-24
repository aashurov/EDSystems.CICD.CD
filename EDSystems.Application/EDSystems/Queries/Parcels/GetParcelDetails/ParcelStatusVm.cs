using AutoMapper;
using EDSystems.Application.Common.Mappings;
using EDSystems.Domain.Entities;
using System;

namespace EDSystems.Application.EDSystems.Queries.Parcels.GetParcelDetails;

public class ParcelStatusVm : IMapWith<Status>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime DateCreated { get; set; } = DateTime.Now;
    public DateTime? DateUpdated { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Status, ParcelStatusVm>()
            .ForMember(parcelStatusVm => parcelStatusVm.Name, opt => opt.MapFrom(status => status.Name))
            .ForMember(parcelStatusVm => parcelStatusVm.Description, opt => opt.MapFrom(status => status.Description))
            .ForMember(parcelStatusVm => parcelStatusVm.DateCreated, opt => opt.MapFrom(status => status.DateCreated))
            .ForMember(parcelStatusVm => parcelStatusVm.DateUpdated, opt => opt.MapFrom(status => status.DateUpdated));
    }
}