using AutoMapper;
using EDSystems.Application.Common.Mappings;
using EDSystems.Application.EDSystems.Commands.Parcels.DeleteParcelImages;

namespace EDSystems.WebApi.Models.Parcel;

/// <summary>
///
/// </summary>
public class DeleteParcelImagesDto : IMapWith<DeleteParcelImagesCommand>
{
    /// <summary>
    ///
    /// </summary>
    public int ParcelId { get; set; }

    /// <summary>
    ///
    /// </summary>
    public IEnumerable<int> ParcelImageId { get; set; }

    /// <summary>
    ///
    /// </summary>
    public void Mapping(Profile profile)
    {
        profile.CreateMap<DeleteParcelImagesDto, DeleteParcelImagesCommand>()
            .ForMember(deleteParcelImagesCommand => deleteParcelImagesCommand.ParcelId,
                options => options.MapFrom(deleteParcelImagesDto => deleteParcelImagesDto.ParcelId))
            .ForMember(deleteParcelImagesCommand => deleteParcelImagesCommand.ParcelImageId,
                options => options.MapFrom(deleteParcelImagesDto => deleteParcelImagesDto.ParcelImageId));
    }
}