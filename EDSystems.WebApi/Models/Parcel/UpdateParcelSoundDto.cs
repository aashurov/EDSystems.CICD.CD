using AutoMapper;
using EDSystems.Application.Common.Mappings;
using EDSystems.Application.EDSystems.Commands.Parcels.UpdateParcelSound;

namespace EDSystems.WebApi.Models.Parcel;

/// <summary>
///
/// </summary>
public class UpdateParcelSoundDto : IMapWith<UpdateParcelSoundCommand>
{
    /// <summary>
    ///
    /// </summary>
    public int ParcelId { get; set; }

    /// <summary>
    ///
    /// </summary>
    public string SoundBytes { get; set; }

    /// <summary>
    ///
    /// </summary>
    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateParcelSoundDto, UpdateParcelSoundCommand>()
            .ForMember(updateParcelSoundCommand => updateParcelSoundCommand.ParcelId,
                options => options.MapFrom(updateParcelSoundDto => updateParcelSoundDto.ParcelId))
            .ForMember(updateParcelSoundCommand => updateParcelSoundCommand.SoundBytes,
                options => options.MapFrom(updateParcelSoundDto => updateParcelSoundDto.SoundBytes));
    }
}