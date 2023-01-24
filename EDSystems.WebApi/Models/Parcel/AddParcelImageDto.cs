using AutoMapper;
using EDSystems.Application.Common.Mappings;
using EDSystems.Application.EDSystems.Commands.Parcels.AddParcelImage;

namespace EDSystems.WebApi.Models.Parcel;

/// <summary>
/// AddParcelImageDto
/// </summary>
public class AddParcelImageDto : IMapWith<AddParcelImageCommand>
{
    /// <summary>
    /// ParcelId
    /// </summary>
    public int ParcelId { get; set; }

    /// <summary>
    ///  Returns a number
    /// </summary>
    /// <returns></returns>
    public string ImageBytes { get; set; }

    /// <summary>
    /// Mapping
    /// </summary>
    /// <param name="profile"></param>
    public void Mapping(Profile profile)
    {
        profile.CreateMap<AddParcelImageDto, AddParcelImageCommand>()
            .ForMember(addParcelImageCommand => addParcelImageCommand.ParcelId,
                options => options.MapFrom(addParcelImageDto => addParcelImageDto.ParcelId))
            .ForMember(addParcelImageCommand => addParcelImageCommand.ImageBytes,
                options => options.MapFrom(addParcelImageDto => addParcelImageDto.ImageBytes));
    }
}