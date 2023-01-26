using AutoMapper;
using EDSystems.Application.Common.Mappings;
using EDSystems.Application.EDSystems.Commands.Parcels.UpdateParcelsStatusById;

namespace EDSystems.WebApi.Models.Parcel;

/// <summary>
///
/// </summary>
public class UpdateParcelsStatusByIdDto : IMapWith<UpdateParcelsStatusByIdCommand>
{
    /// <summary>
    ///
    /// </summary>
    public ICollection<int> ParcelId { get; set; }

    /// <summary>
    ///
    /// </summary>
    public int StatusId { get; set; }

    /// <summary>
    ///
    /// </summary>
    public string SenderId { get; set; }

    /// <summary>
    ///
    /// </summary>
    public string RecepientId { get; set; }

    /// <summary>
    ///
    /// </summary>
    public string RecepientStaffId { get; set; }

    /// <summary>
    ///
    /// </summary>
    public string SenderStaffId { get; set; }

    /// <summary>
    ///
    /// </summary>
    public string RecepientCourierId { get; set; }

    /// <summary>
    ///
    /// </summary>
    public string SenderCourierId { get; set; }

    /// <summary>
    ///
    /// </summary>
    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateParcelsStatusByIdDto, UpdateParcelsStatusByIdCommand>()
            .ForMember(updateParcelCommand => updateParcelCommand.StatusId,
                options => options.MapFrom(updateParcelDto => updateParcelDto.StatusId))
            .ForMember(updateParcelCommand => updateParcelCommand.SenderId,
                options => options.MapFrom(updateParcelDto => updateParcelDto.SenderId))
        .ForMember(updateParcelCommand => updateParcelCommand.RecepientId,
                options => options.MapFrom(updateParcelDto => updateParcelDto.RecepientId))
        .ForMember(updateParcelCommand => updateParcelCommand.RecepientStaffId,
                options => options.MapFrom(updateParcelDto => updateParcelDto.RecepientStaffId))
         .ForMember(updateParcelCommand => updateParcelCommand.SenderStaffId,
                options => options.MapFrom(updateParcelDto => updateParcelDto.SenderStaffId))
         .ForMember(updateParcelCommand => updateParcelCommand.RecepientCourierId,
                options => options.MapFrom(updateParcelDto => updateParcelDto.RecepientCourierId))
         .ForMember(updateParcelCommand => updateParcelCommand.SenderCourierId,
                options => options.MapFrom(updateParcelDto => updateParcelDto.SenderCourierId))
         .ForMember(updateParcelCommand => updateParcelCommand.ParcelId,
                options => options.MapFrom(updateParcelDto => updateParcelDto.ParcelId));
    }
}