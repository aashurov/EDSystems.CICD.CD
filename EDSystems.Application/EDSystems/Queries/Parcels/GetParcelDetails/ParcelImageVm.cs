using AutoMapper;
using EDSystems.Application.Common.Mappings;
using EDSystems.Domain.Entities;

namespace EDSystems.Application.EDSystems.Queries.Parcels.GetParcelDetails;

public class ParcelImageVm : IMapWith<ParcelImage>
{
    public string ImageName { get; set; }
    public string ImageBytes { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<ParcelImage, ParcelImageVm>()
            .ForMember(parcelImageVm => parcelImageVm.ImageName, opt => opt.MapFrom(parcelImage => parcelImage.ImageName))
            .ForMember(parcelImageVm => parcelImageVm.ImageBytes, opt => opt.MapFrom(parcelImage => parcelImage.ImageBytes));
    }
}