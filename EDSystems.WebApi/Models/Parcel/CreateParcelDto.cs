using AutoMapper;
using EDSystems.Application.Common.Mappings;
using EDSystems.Application.EDSystems.Commands.Parcels.CreateParcel;
using EDSystems.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace EDSystems.WebApi.Models.Parcel;

/// <summary>
///
/// </summary>
public class CreateParcelDto : IMapWith<CreateParcelCommand>
{
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
    public virtual ICollection<ParcelItem> ParcelItem { get; set; }

    /// <summary>
    ///
    /// </summary>
    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateParcelDto, CreateParcelCommand>()
            .ForMember(createParcelCommand => createParcelCommand.ParcelCost,
                options => options.MapFrom(createParcelDto => createParcelDto.ParcelCost))
        .ForMember(createParcelCommand => createParcelCommand.SenderId,
                options => options.MapFrom(createParcelDto => createParcelDto.SenderId))
        .ForMember(createParcelCommand => createParcelCommand.RecepientId,
                options => options.MapFrom(createParcelDto => createParcelDto.RecepientId))
        .ForMember(createParcelCommand => createParcelCommand.RecepientStaffId,
                options => options.MapFrom(createParcelDto => createParcelDto.RecepientStaffId))
         .ForMember(createParcelCommand => createParcelCommand.SenderStaffId,
                options => options.MapFrom(createParcelDto => createParcelDto.SenderStaffId))
         .ForMember(createParcelCommand => createParcelCommand.RecepientCourierId,
                options => options.MapFrom(createParcelDto => createParcelDto.RecepientCourierId))
         .ForMember(createParcelCommand => createParcelCommand.SenderCourierId,
                options => options.MapFrom(createParcelDto => createParcelDto.SenderCourierId))
         .ForMember(createParcelCommand => createParcelCommand.ParcelPlanId,
                options => options.MapFrom(createParcelDto => createParcelDto.ParcelPlanId))
         .ForMember(createParcelCommand => createParcelCommand.ParcelBranchFromId,
                options => options.MapFrom(createParcelDto => createParcelDto.ParcelBranchFromId))
         .ForMember(createParcelCommand => createParcelCommand.ParcelBranchToId,
                options => options.MapFrom(createParcelDto => createParcelDto.ParcelBranchToId))
         .ForMember(createParcelCommand => createParcelCommand.ParcelSize,
                options => options.MapFrom(createParcelDto => createParcelDto.ParcelSize))
        .ForMember(createParcelCommand => createParcelCommand.ParcelStatusId,
                options => options.MapFrom(createParcelDto => createParcelDto.ParcelStatusId))
        .ForMember(createParcelCommand => createParcelCommand.ParcelImage,
                options => options.MapFrom(createParcelDto => createParcelDto.ParcelImage))
        .ForMember(createParcelCommand => createParcelCommand.ParcelSound,
                options => options.MapFrom(createParcelDto => createParcelDto.ParcelSound))
        .ForMember(createParcelCommand => createParcelCommand.ParcelItem,
                options => options.MapFrom(createParcelDto => createParcelDto.ParcelItem))
        .ForMember(createParcelCommand => createParcelCommand.ParcelDescription,
                options => options.MapFrom(createParcelDto => createParcelDto.ParcelDescription));
    }
}