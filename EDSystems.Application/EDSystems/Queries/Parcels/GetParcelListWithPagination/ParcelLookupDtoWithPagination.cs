using AutoMapper;
using EDSystems.Application.Common.Mappings;
using EDSystems.Application.EDSystems.Queries.Parcels.GetParcelDetails;
using EDSystems.Application.EDSystems.Queries.Parcels.GetParcelList;
using EDSystems.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EDSystems.Application.EDSystems.Queries.Parcels.GetParcelListWithPagination;

public class ParcelLookupDtoWithPagination : IMapWith<Parcel>
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
        profile.CreateMap<Parcel, ParcelLookupDtoWithPagination>()

            .ForMember(parcelLookupWithPaginationDto => parcelLookupWithPaginationDto.Id, opt => opt.MapFrom(parcel => parcel.Id))
            .ForMember(parcelLookupWithPaginationDto => parcelLookupWithPaginationDto.Code, opt => opt.MapFrom(parcel => parcel.Code))
            .ForMember(parcelLookupWithPaginationDto => parcelLookupWithPaginationDto.FromBranch, opt => opt.MapFrom(parcel => parcel.ParcelBranch.FromBranch))
            .ForMember(parcelLookupWithPaginationDto => parcelLookupWithPaginationDto.ToBranch, opt => opt.MapFrom(parcel => parcel.ParcelBranch.ToBranch))
            .ForMember(parcelLookupWithPaginationDto => parcelLookupWithPaginationDto.ParcelCost, opt => opt.MapFrom(parcel => parcel.ParcelCost))
            .ForMember(parcelLookupWithPaginationDto => parcelLookupWithPaginationDto.ParcelDescription, opt => opt.MapFrom(parcel => parcel.ParcelDescription))
            .ForMember(parcelLookupWithPaginationDto => parcelLookupWithPaginationDto.ParcelImage, opt => opt.MapFrom(parcel => parcel.ParcelImage))
            .ForMember(parcelLookupWithPaginationDto => parcelLookupWithPaginationDto.ParcelSound, opt => opt.MapFrom(parcel => parcel.ParcelSound))

            .ForMember(parcelLookupWithPaginationDto => parcelLookupWithPaginationDto.ParcelPlan, opt => opt.MapFrom(parcel => parcel.ParcelPlan.Plan))
            .ForMember(parcelLookupWithPaginationDto => parcelLookupWithPaginationDto.ParcelSize, opt => opt.MapFrom(parcel => parcel.ParcelSize))

            .ForMember(parcelLookupWithPaginationDto => parcelLookupWithPaginationDto.Recepient, opt => opt.MapFrom(parcel => parcel.ParcelOwners.Recepient))
            .ForMember(parcelLookupWithPaginationDto => parcelLookupWithPaginationDto.RecepientStaff, opt => opt.MapFrom(parcel => parcel.ParcelOwners.RecepientStaff))
            .ForMember(parcelLookupWithPaginationDto => parcelLookupWithPaginationDto.RecepientCourier, opt => opt.MapFrom(parcel => parcel.ParcelOwners.RecepientCourier))

            .ForMember(parcelLookupWithPaginationDto => parcelLookupWithPaginationDto.Sender, opt => opt.MapFrom(parcel => parcel.ParcelOwners.Sender))
            .ForMember(parcelLookupWithPaginationDto => parcelLookupWithPaginationDto.SenderStaff, opt => opt.MapFrom(parcel => parcel.ParcelOwners.SenderStaff))
            .ForMember(parcelLookupWithPaginationDto => parcelLookupWithPaginationDto.SenderCourier, opt => opt.MapFrom(parcel => parcel.ParcelOwners.SenderCourier))

            .ForMember(parcelLookupWithPaginationDto => parcelLookupWithPaginationDto.ParcelStatus, opt => opt.MapFrom(src => src.ParcelStatus.Select(x => x.Status)))
            .ForMember(parcelLookupWithPaginationDto => parcelLookupWithPaginationDto.DateCreated, opt => opt.MapFrom(parcel => parcel.DateCreated))
            .ForMember(parcelLookupWithPaginationDto => parcelLookupWithPaginationDto.DateUpdated, opt => opt.MapFrom(parcel => parcel.DateUpdated));
    }
}