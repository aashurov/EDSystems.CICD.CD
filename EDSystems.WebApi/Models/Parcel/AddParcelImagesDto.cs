using AutoMapper;
using EDSystems.Application.Common.Mappings;
using EDSystems.Application.EDSystems.Commands.Parcels.AddParcelImages;

namespace EDSystems.WebApi.Models.Parcel;

/// <summary>
///
/// </summary>
public class AddParcelImagesDto : IMapWith<AddParcelImagesCommand>
{
    /// <summary>
    ///  ParcelId
    /// </summary>
    public int ParcelId { get; set; }

    /// <summary>
    ///  ImageBytes
    /// </summary>
    public IEnumerable<string> ImageBytes { get; set; }

    /// <summary>
    ///  Mapping
    /// </summary>
    public void Mapping(Profile profile)
    {
        profile.CreateMap<AddParcelImagesDto, AddParcelImagesCommand>()
            .ForMember(addParcelImagesCommand => addParcelImagesCommand.ParcelId,
                options => options.MapFrom(addParcelImageDto => addParcelImageDto.ParcelId))
            .ForMember(addParcelImagesCommand => addParcelImagesCommand.ImageBytes,
                options => options.MapFrom(addParcelImagesDto => addParcelImagesDto.ImageBytes));
    }
}