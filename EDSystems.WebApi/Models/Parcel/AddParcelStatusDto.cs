using AutoMapper;
using EDSystems.Application.Common.Mappings;
using EDSystems.Application.EDSystems.Commands.Parcels.AddParcelStatus;

namespace EDSystems.WebApi.Models.Parcel;

/// <summary>
///
/// </summary>
public class AddParcelStatusDto : IMapWith<AddParcelStatusCommand>
{
    /// <summary>
    ///
    /// </summary>
    public int ParcelId { get; set; }

    /// <summary>
    ///
    /// </summary>
    public int ParcelStatusId { get; set; }

    /// <summary>
    ///
    /// </summary>
    public string RecepientCourierId { get; set; }

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
    public string SenderCourierId { get; set; }

    /// <summary>
    ///
    /// </summary>
    public string SenderId { get; set; }

    /// <summary>
    ///
    /// </summary>
    public string SenderStaffId { get; set; }

    /// <summary>
    ///
    /// </summary>

    public void Mapping(Profile profile)
    {
        profile.CreateMap<AddParcelStatusDto, AddParcelStatusCommand>()
            .ForMember(addParcelStatusCommand => addParcelStatusCommand.ParcelStatusId,
                options => options.MapFrom(addParcelStatusDto => addParcelStatusDto.ParcelStatusId))
            .ForMember(addParcelStatusCommand => addParcelStatusCommand.SenderId,
                options => options.MapFrom(addParcelStatusDto => addParcelStatusDto.SenderId))
            .ForMember(addParcelStatusCommand => addParcelStatusCommand.RecepientId,
                options => options.MapFrom(addParcelStatusDto => addParcelStatusDto.RecepientId))
            .ForMember(addParcelStatusCommand => addParcelStatusCommand.RecepientStaffId,
                options => options.MapFrom(addParcelStatusDto => addParcelStatusDto.RecepientStaffId))
            .ForMember(addParcelStatusCommand => addParcelStatusCommand.SenderStaffId,
                options => options.MapFrom(addParcelStatusDto => addParcelStatusDto.SenderStaffId))
            .ForMember(addParcelStatusCommand => addParcelStatusCommand.RecepientCourierId,
                options => options.MapFrom(addParcelStatusDto => addParcelStatusDto.RecepientCourierId))
            .ForMember(addParcelStatusCommand => addParcelStatusCommand.SenderCourierId,
                options => options.MapFrom(addParcelStatusDto => addParcelStatusDto.SenderCourierId))
            .ForMember(addParcelStatusCommand => addParcelStatusCommand.ParcelId,
                options => options.MapFrom(addParcelStatusDto => addParcelStatusDto.ParcelId));
    }
}