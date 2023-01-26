using AutoMapper;
using EDSystems.Application.Common.Mappings;
using EDSystems.Application.EDSystems.Commands.Parcels.UpdateParcelImage;

namespace EDSystems.WebApi.Models.Parcel;

/// <summary>
///
/// </summary>
public class UpdateParcelImageDto : IMapWith<UpdateParcelImageCommand>
{
    /// <summary>
    ///
    /// </summary>
    public int ParcelId { get; set; }

    /// <summary>
    ///
    /// </summary>
    public string ImageBytes { get; set; }

    /// <summary>
    ///
    /// </summary>
    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateParcelImageDto, UpdateParcelImageCommand>()
            .ForMember(updateParcelImageCommand => updateParcelImageCommand.ParcelId,
                options => options.MapFrom(updateParcelImageDto => updateParcelImageDto.ParcelId))
            .ForMember(updateParcelImageCommand => updateParcelImageCommand.ImageBytes,
                options => options.MapFrom(updateParcelImageDto => updateParcelImageDto.ImageBytes));
    }
}