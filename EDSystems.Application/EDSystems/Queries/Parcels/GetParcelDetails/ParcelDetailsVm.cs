using AutoMapper;
using EDSystems.Application.Common.Mappings;
using EDSystems.Domain.Entities;
using System;
using System.Collections.Generic;

namespace EDSystems.Application.EDSystems.Queries.Parcels.GetParcelDetails;

public class ParcelDetailsVm : IMapWith<Parcel>
{
    public int Id { get; set; }
    public string Code { get; set; }
    public virtual ParcelCost ParcelCost { get; set; }
    public virtual ParcelUserVm Recepient { get; set; }
    public virtual ParcelUserVm RecepientStaff { get; set; }
    public virtual ParcelUserVm RecepientCourier { get; set; }
    public virtual ParcelUserVm Sender { get; set; }
    public virtual ParcelUserVm SenderStaff { get; set; }
    public virtual ParcelUserVm SenderCourier { get; set; }
    public virtual ParcelPlanVm ParcelPlan { get; set; }
    public virtual ParcelSize ParcelSize { get; set; }
    public virtual ParcelBranchVm FromBranch { get; set; }
    public virtual ParcelBranchVm ToBranch { get; set; }
    public virtual ICollection<ParcelStatus> ParcelStatus { get; set; }
    public virtual ICollection<ParcelImage> ParcelImage { get; set; }
    public virtual ICollection<ParcelSound> ParcelSound { get; set; }
    public virtual ICollection<ParcelItem> ParcelItem { get; set; }
    public virtual ParcelDescriptionVm ParcelDescription { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime? DateUpdated { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Parcel, ParcelDetailsVm>()
            .ForMember(parcelDetailsVm => parcelDetailsVm.Id, opt => opt.MapFrom(parcel => parcel.Id))
            .ForMember(parcelDetailsVm => parcelDetailsVm.Code, opt => opt.MapFrom(parcel => parcel.Code))
            .ForMember(parcelDetailsVm => parcelDetailsVm.FromBranch, opt => opt.MapFrom(parcel => parcel.ParcelBranch.FromBranch))
            .ForMember(parcelDetailsVm => parcelDetailsVm.ToBranch, opt => opt.MapFrom(parcel => parcel.ParcelBranch.ToBranch))
            .ForMember(parcelDetailsVm => parcelDetailsVm.ParcelCost, opt => opt.MapFrom(parcel => parcel.ParcelCost))
            .ForMember(parcelDetailsVm => parcelDetailsVm.ParcelDescription, opt => opt.MapFrom(parcel => parcel.ParcelDescription))
            .ForMember(parcelDetailsVm => parcelDetailsVm.ParcelImage, opt => opt.MapFrom(parcel => parcel.ParcelImage))
            .ForMember(parcelDetailsVm => parcelDetailsVm.ParcelSound, opt => opt.MapFrom(parcel => parcel.ParcelSound))
            .ForMember(parcelDetailsVm => parcelDetailsVm.ParcelItem, opt => opt.MapFrom(parcel => parcel.ParcelItem))

            .ForMember(parcelDetailsVm => parcelDetailsVm.Recepient, opt => opt.MapFrom(parcel => parcel.ParcelOwners.Recepient))
            .ForMember(parcelDetailsVm => parcelDetailsVm.RecepientStaff, opt => opt.MapFrom(parcel => parcel.ParcelOwners.RecepientStaff))
            .ForMember(parcelDetailsVm => parcelDetailsVm.RecepientCourier, opt => opt.MapFrom(parcel => parcel.ParcelOwners.RecepientCourier))
            .ForMember(parcelDetailsVm => parcelDetailsVm.Sender, opt => opt.MapFrom(parcel => parcel.ParcelOwners.Sender))
            .ForMember(parcelDetailsVm => parcelDetailsVm.SenderStaff, opt => opt.MapFrom(parcel => parcel.ParcelOwners.SenderStaff))
            .ForMember(parcelDetailsVm => parcelDetailsVm.SenderCourier, opt => opt.MapFrom(parcel => parcel.ParcelOwners.SenderCourier))

            .ForMember(parcelDetailsVm => parcelDetailsVm.ParcelPlan, opt => opt.MapFrom(parcel => parcel.ParcelPlan.Plan))
            .ForMember(parcelDetailsVm => parcelDetailsVm.ParcelSize, opt => opt.MapFrom(parcel => parcel.ParcelSize))
            .ForMember(parcelDetailsVm => parcelDetailsVm.ParcelStatus, opt => opt.MapFrom(parcel => parcel.ParcelStatus))
            .ForMember(parcelDetailsVm => parcelDetailsVm.DateCreated, opt => opt.MapFrom(parcel => parcel.DateCreated))
            .ForMember(parcelDetailsVm => parcelDetailsVm.DateUpdated, opt => opt.MapFrom(parcel => parcel.DateUpdated));
    }
}