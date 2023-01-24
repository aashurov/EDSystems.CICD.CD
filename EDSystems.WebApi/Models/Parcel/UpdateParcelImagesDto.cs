using AutoMapper;
using EDSystems.Application.Common.Mappings;
using EDSystems.Application.EDSystems.Commands.Parcels.UpdateParcelImages;

namespace EDSystems.WebApi.Models.Parcel;

/// <summary>
///
/// </summary>
public class UpdateParcelImagesDto : IMapWith<UpdateParcelImagesCommand>
{
    /// <summary>
    ///
    /// </summary>
    public int ParcelId { get; set; }

    /// <summary>
    ///
    /// </summary>
    public IEnumerable<string> ImageBytes { get; set; }

    /// <summary>
    ///
    /// </summary>
    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateParcelImagesDto, UpdateParcelImagesCommand>()
            .ForMember(updateParcelImagesCommand => updateParcelImagesCommand.ParcelId,
                options => options.MapFrom(updateParcelImagesDto => updateParcelImagesDto.ParcelId))
            .ForMember(updateParcelImagesCommand => updateParcelImagesCommand.ImageBytes,
                options => options.MapFrom(updateParcelImagesDto => updateParcelImagesDto.ImageBytes));
    }
}