using AutoMapper;
using EDSystems.Application.Common.Mappings;
using EDSystems.Application.EDSystems.Commands.Parcels.DeleteImageFromParcel;

namespace EDSystems.WebApi.Models.Parcel;

/// <summary>
///
/// </summary>
public class DeleteParcelImageDto : IMapWith<DeleteParcelImageCommand>
{
    /// <summary>
    ///
    /// </summary>
    public int ParcelId { get; set; }

    /// <summary>
    ///
    /// </summary>
    public int ParcelImageId { get; set; }

    /// <summary>
    ///
    /// </summary>
    public void Mapping(Profile profile)
    {
        profile.CreateMap<DeleteParcelImageDto, DeleteParcelImageCommand>()
            .ForMember(deleteParcelImageCommand => deleteParcelImageCommand.ParcelId,
                options => options.MapFrom(deleteParcelImageDto => deleteParcelImageDto.ParcelId))
            .ForMember(deleteParcelImageCommand => deleteParcelImageCommand.ParcelImageId,
                options => options.MapFrom(deleteParcelImageDto => deleteParcelImageDto.ParcelImageId));
    }
}