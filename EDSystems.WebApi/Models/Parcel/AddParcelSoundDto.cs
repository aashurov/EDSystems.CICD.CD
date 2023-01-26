using AutoMapper;
using EDSystems.Application.Common.Mappings;
using EDSystems.Application.EDSystems.Commands.Parcels.AddParcelSound;

namespace EDSystems.WebApi.Models.Parcel;

/// <summary>
///
/// </summary>
public class AddParcelSoundDto : IMapWith<AddParcelSoundCommand>
{
    /// <summary>
    ///
    /// </summary>
    public int? ParcelId { get; set; }

    /// <summary>
    ///
    /// </summary>
    public string SoundBytes { get; set; }

    /// <summary>
    ///
    /// </summary>
    public void Mapping(Profile profile)
    {
        profile.CreateMap<AddParcelSoundDto, AddParcelSoundCommand>()
            .ForMember(addParcelSoundCommand => addParcelSoundCommand.ParcelId,
                options => options.MapFrom(addParcelSoundDto => addParcelSoundDto.ParcelId))
            .ForMember(addParcelSoundCommand => addParcelSoundCommand.SoundBytes,
                options => options.MapFrom(addParcelSoundDto => addParcelSoundDto.SoundBytes));
    }
}