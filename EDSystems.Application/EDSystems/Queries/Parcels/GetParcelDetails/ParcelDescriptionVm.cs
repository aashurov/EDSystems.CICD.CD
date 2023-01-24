using AutoMapper;
using EDSystems.Application.Common.Mappings;
using EDSystems.Domain.Entities;

namespace EDSystems.Application.EDSystems.Queries.Parcels.GetParcelDetails;

public class ParcelDescriptionVm : IMapWith<ParcelDescription>
{
    public string Description { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<ParcelDescription, ParcelDescriptionVm>()
            .ForMember(parcelDescriptionVm => parcelDescriptionVm.Description, opt => opt.MapFrom(parcelDescription => parcelDescription.Description));
    }
}