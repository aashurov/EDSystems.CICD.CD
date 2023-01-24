using AutoMapper;
using EDSystems.Application.Common.Mappings;
using EDSystems.Application.EDSystems.Commands.Parcels.DeleteParcelStatus;

namespace EDSystems.WebApi.Models.Parcel;

/// <summary>
///
/// </summary>
public class DeleteParcelStatusDto : IMapWith<DeleteParcelStatusCommand>
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
    public int StatusId { get; set; }

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
        profile.CreateMap<DeleteParcelStatusDto, DeleteParcelStatusCommand>()
            .ForMember(deleteParcelStatusCommand => deleteParcelStatusCommand.ParcelStatusId,
                options => options.MapFrom(deleteParcelStatusDto => deleteParcelStatusDto.ParcelStatusId))
             .ForMember(deleteParcelStatusCommand => deleteParcelStatusCommand.StatusId,
                options => options.MapFrom(deleteParcelStatusDto => deleteParcelStatusDto.StatusId))
            .ForMember(deleteParcelStatusCommand => deleteParcelStatusCommand.SenderId,
                options => options.MapFrom(deleteParcelStatusDto => deleteParcelStatusDto.SenderId))
            .ForMember(deleteParcelStatusCommand => deleteParcelStatusCommand.RecepientId,
                options => options.MapFrom(deleteParcelStatusDto => deleteParcelStatusDto.RecepientId))
            .ForMember(deleteParcelStatusCommand => deleteParcelStatusCommand.RecepientStaffId,
                options => options.MapFrom(deleteParcelStatusDto => deleteParcelStatusDto.RecepientStaffId))
            .ForMember(deleteParcelStatusCommand => deleteParcelStatusCommand.SenderStaffId,
                options => options.MapFrom(deleteParcelStatusDto => deleteParcelStatusDto.SenderStaffId))
            .ForMember(deleteParcelStatusCommand => deleteParcelStatusCommand.RecepientCourierId,
                options => options.MapFrom(deleteParcelStatusDto => deleteParcelStatusDto.RecepientCourierId))
            .ForMember(deleteParcelStatusCommand => deleteParcelStatusCommand.SenderCourierId,
                options => options.MapFrom(deleteParcelStatusDto => deleteParcelStatusDto.SenderCourierId))
            .ForMember(deleteParcelStatusCommand => deleteParcelStatusCommand.ParcelId,
                options => options.MapFrom(deleteParcelStatusDto => deleteParcelStatusDto.ParcelId));
    }
}