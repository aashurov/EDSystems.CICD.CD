using AutoMapper;
using EDSystems.Application.Common.Mappings;
using EDSystems.Application.EDSystems.Commands.Parcels.DeleteParcelSound;

namespace EDSystems.WebApi.Models.Parcel;

/// <summary>
///
/// </summary>
public class DeleteParcelSoundDto : IMapWith<DeleteParcelSoundCommand>
{
    /// <summary>
    ///
    /// </summary>
    public int ParcelId { get; set; }

    /// <summary>
    ///
    /// </summary>
    public int ParcelSoundId { get; set; }

    /// <summary>
    ///
    /// </summary>
    public void Mapping(Profile profile)
    {
        profile.CreateMap<DeleteParcelSoundDto, DeleteParcelSoundCommand>()
            .ForMember(deleteParcelSoundCommand => deleteParcelSoundCommand.ParcelId,
                options => options.MapFrom(deleteParcelSoundDto => deleteParcelSoundDto.ParcelId))
            .ForMember(deleteParcelSoundCommand => deleteParcelSoundCommand.ParcelSoundId,
                options => options.MapFrom(deleteParcelSoundDto => deleteParcelSoundDto.ParcelSoundId));
    }
}