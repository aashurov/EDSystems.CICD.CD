using AutoMapper;
using EDSystems.Application.Common.Mappings;
using EDSystems.Application.EDSystems.Queries.Parcels.GetParcelDetails;
using EDSystems.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EDSystems.Application.EDSystems.Queries.Parcels.GetParcelList;

public class ParcelLookupDto : IMapWith<Parcel>
{
    public int Id { get; set; }
    public string Code { get; set; }
    public virtual ParcelCost ParcelCost { get; set; }
    public virtual ParcelPlanVm ParcelPlan { get; set; }
    public virtual ParcelSize ParcelSize { get; set; }
    public virtual ParcelBranchVm FromBranch { get; set; }
    public virtual ParcelBranchVm ToBranch { get; set; }
    public virtual ICollection<StatusVm> ParcelStatus { get; set; }
    public virtual ICollection<ParcelImage> ParcelImage { get; set; }
    public virtual ICollection<ParcelSound> ParcelSound { get; set; }
    public virtual ICollection<ParcelItem> ParcelItem { get; set; }
    public virtual ParcelDescriptionVm ParcelDescription { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime? DateUpdated { get; set; }
    public virtual ParcelUserVm Recepient { get; set; }
    public virtual ParcelUserVm RecepientStaff { get; set; }
    public virtual ParcelUserVm RecepientCourier { get; set; }
    public virtual ParcelUserVm Sender { get; set; }
    public virtual ParcelUserVm SenderStaff { get; set; }
    public virtual ParcelUserVm SenderCourier { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Parcel, ParcelLookupDto>()

            .ForMember(parcelLookupDto => parcelLookupDto.Id, opt => opt.MapFrom(parcel => parcel.Id))
            .ForMember(parcelLookupDto => parcelLookupDto.Code, opt => opt.MapFrom(parcel => parcel.Code))
            .ForMember(parcelLookupDto => parcelLookupDto.FromBranch, opt => opt.MapFrom(parcel => parcel.ParcelBranch.FromBranch))
            .ForMember(parcelLookupDto => parcelLookupDto.ToBranch, opt => opt.MapFrom(parcel => parcel.ParcelBranch.ToBranch))
            .ForMember(parcelLookupDto => parcelLookupDto.ParcelCost, opt => opt.MapFrom(parcel => parcel.ParcelCost))
            .ForMember(parcelLookupDto => parcelLookupDto.ParcelDescription, opt => opt.MapFrom(parcel => parcel.ParcelDescription))
            .ForMember(parcelLookupDto => parcelLookupDto.ParcelImage, opt => opt.MapFrom(parcel => parcel.ParcelImage))
            .ForMember(parcelLookupDto => parcelLookupDto.ParcelSound, opt => opt.MapFrom(parcel => parcel.ParcelSound))
            .ForMember(parcelLookupDto => parcelLookupDto.ParcelItem, opt => opt.MapFrom(parcel => parcel.ParcelItem))

            .ForMember(parcelLookupDto => parcelLookupDto.ParcelPlan, opt => opt.MapFrom(parcel => parcel.ParcelPlan.Plan))
            .ForMember(parcelLookupDto => parcelLookupDto.ParcelSize, opt => opt.MapFrom(parcel => parcel.ParcelSize))

            .ForMember(parcelLookupDto => parcelLookupDto.Recepient, opt => opt.MapFrom(parcel => parcel.ParcelOwners.Recepient))
            .ForMember(parcelLookupDto => parcelLookupDto.RecepientStaff, opt => opt.MapFrom(parcel => parcel.ParcelOwners.RecepientStaff))
            .ForMember(parcelLookupDto => parcelLookupDto.RecepientCourier, opt => opt.MapFrom(parcel => parcel.ParcelOwners.RecepientCourier))

            .ForMember(parcelLookupDto => parcelLookupDto.Sender, opt => opt.MapFrom(parcel => parcel.ParcelOwners.Sender))
            .ForMember(parcelLookupDto => parcelLookupDto.SenderStaff, opt => opt.MapFrom(parcel => parcel.ParcelOwners.SenderStaff))
            .ForMember(parcelLookupDto => parcelLookupDto.SenderCourier, opt => opt.MapFrom(parcel => parcel.ParcelOwners.SenderCourier))

            .ForMember(parcelLookupDto => parcelLookupDto.ParcelStatus, opt => opt.MapFrom(src => src.ParcelStatus.Select(x => x.Status)))
            .ForMember(parcelLookupDto => parcelLookupDto.DateCreated, opt => opt.MapFrom(parcel => parcel.DateCreated))
            .ForMember(parcelLookupDto => parcelLookupDto.DateUpdated, opt => opt.MapFrom(parcel => parcel.DateUpdated));
    }
}