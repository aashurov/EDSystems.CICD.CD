using AutoMapper;
using EDSystems.Application.Common.Mappings;
using EDSystems.Application.EDSystems.Commands.Parcels.AddParcelSounds;

namespace EDSystems.WebApi.Models.Parcel;

/// <summary>
///
/// </summary>
public class AddParcelSoundsDto : IMapWith<AddParcelSoundsCommand>
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
        profile.CreateMap<AddParcelSoundsDto, AddParcelSoundsCommand>()
            .ForMember(addParcelSoundsCommand => addParcelSoundsCommand.ParcelId,
                options => options.MapFrom(addParcelSoundsDto => addParcelSoundsDto.ParcelId))
            .ForMember(addParcelSoundsCommand => addParcelSoundsCommand.SoundBytes,
                options => options.MapFrom(addParcelSoundsDto => addParcelSoundsDto.SoundBytes));
    }
}