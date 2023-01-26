using AutoMapper;
using EDSystems.Application.Common.Mappings;
using EDSystems.Application.EDSystems.Commands.Parcels.UpdateParcel;
using EDSystems.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace EDSystems.WebApi.Models.Parcel;

/// <summary>
///
/// </summary>
public class UpdateParcelDto : IMapWith<UpdateParcelCommand>
{
    /// <summary>
    ///
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    ///
    /// </summary>

    [Required]
    public virtual ParcelCost ParcelCost { get; set; }

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
    public int ParcelPlanId { get; set; }

    /// <summary>
    ///
    /// </summary>
    public int ParcelBranchFromId { get; set; }

    /// <summary>
    ///
    /// </summary>
    public int ParcelBranchToId { get; set; }

    /// <summary>
    ///
    /// </summary>
    public virtual ParcelSize ParcelSize { get; set; }

    /// <summary>
    ///
    /// </summary>
    public int ParcelStatusId { get; set; }

    /// <summary>
    ///
    /// </summary>
    public virtual ICollection<ParcelImage> ParcelImage { get; set; }

    /// <summary>
    ///
    /// </summary>
    public virtual ICollection<ParcelSound> ParcelSound { get; set; }

    /// <summary>
    ///
    /// </summary>
    public virtual ParcelDescription ParcelDescription { get; set; }

    /// <summary>
    ///
    /// </summary>
    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateParcelDto, UpdateParcelCommand>()
            .ForMember(updateParcelCommand => updateParcelCommand.Id,
                options => options.MapFrom(updateParcelDto => updateParcelDto.Id))
            .ForMember(updateParcelCommand => updateParcelCommand.ParcelCost,
                options => options.MapFrom(updateParcelDto => updateParcelDto.ParcelCost))
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
         .ForMember(updateParcelCommand => updateParcelCommand.ParcelPlanId,
                options => options.MapFrom(updateParcelDto => updateParcelDto.ParcelPlanId))
         .ForMember(updateParcelCommand => updateParcelCommand.ParcelBranchFromId,
                options => options.MapFrom(updateParcelDto => updateParcelDto.ParcelBranchFromId))
         .ForMember(updateParcelCommand => updateParcelCommand.ParcelBranchToId,
                options => options.MapFrom(updateParcelDto => updateParcelDto.ParcelBranchToId))
         .ForMember(updateParcelCommand => updateParcelCommand.ParcelSize,
                options => options.MapFrom(updateParcelDto => updateParcelDto.ParcelSize))
        .ForMember(updateParcelCommand => updateParcelCommand.ParcelStatusId,
                options => options.MapFrom(updateParcelDto => updateParcelDto.ParcelStatusId))
        .ForMember(updateParcelCommand => updateParcelCommand.ParcelImage,
                options => options.MapFrom(updateParcelDto => updateParcelDto.ParcelImage))
        .ForMember(updateParcelCommand => updateParcelCommand.ParcelSound,
                options => options.MapFrom(updateParcelDto => updateParcelDto.ParcelSound))
        .ForMember(updateParcelCommand => updateParcelCommand.ParcelDescription,
                options => options.MapFrom(updateParcelDto => updateParcelDto.ParcelDescription));
    }
}