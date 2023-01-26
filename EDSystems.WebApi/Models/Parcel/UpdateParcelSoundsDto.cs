using AutoMapper;
using EDSystems.Application.Common.Mappings;
using EDSystems.Application.EDSystems.Commands.Parcels.UpdateParcelSounds;

namespace EDSystems.WebApi.Models.Parcel;

/// <summary>
///
/// </summary>
public class UpdateParcelSoundsDto : IMapWith<UpdateParcelSoundsCommand>
{
    /// <summary>
    ///
    /// </summary>
    public int ParcelId { get; set; }

    /// <summary>
    ///
    /// </summary>
    public IEnumerable<string> SoundBytes { get; set; }

    /// <summary>
    ///
    /// </summary>
    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateParcelSoundsDto, UpdateParcelSoundsCommand>()
            .ForMember(updateParcelSoundsDto => updateParcelSoundsDto.ParcelId,
                options => options.MapFrom(updateParcelImagesDto => updateParcelImagesDto.ParcelId))
            .ForMember(updateParcelSoundsCommand => updateParcelSoundsCommand.SoundBytes,
                options => options.MapFrom(updateParcelSoundsDto => updateParcelSoundsDto.SoundBytes));
    }
}