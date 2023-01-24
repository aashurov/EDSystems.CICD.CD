using AutoMapper;
using EDSystems.Application.Common.Mappings;
using EDSystems.Domain.Entities;
using EDSystems.Domain.Entities.UserEntities;
using System;
using System.Collections.Generic;

namespace EDSystems.Application.EDSystems.Queries.ParcelJobs.GetParcelJobDetails;

public class ParcelJobDetailsVm : IMapWith<ParcelJob>
{
    public int Id { get; set; }
    public decimal Cost { get; set; }
    public ICollection<User> Courier { get; set; }
    public string CourierId { get; set; }
    public string JobType { get; set; }
    public int ParcelId { get; set; }
    public Parcel Parcel { get; set; }
    public bool PaymentState { get; set; } //zabor dostavka
    public DateTime DateCreated { get; set; }
    public DateTime? DateUpdated { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<ParcelJob, ParcelJobDetailsVm>()
            .ForMember(parcelJobDetailsVm => parcelJobDetailsVm.Id, opt => opt.MapFrom(parcelJob => parcelJob.Id))
            .ForMember(parcelJobDetailsVm => parcelJobDetailsVm.Cost, opt => opt.MapFrom(parcelJob => parcelJob.Cost))
            .ForMember(parcelJobDetailsVm => parcelJobDetailsVm.Courier, opt => opt.MapFrom(parcelJob => parcelJob.Courier))
            .ForMember(parcelJobDetailsVm => parcelJobDetailsVm.JobType, opt => opt.MapFrom(parcelJob => parcelJob.JobType))
            .ForMember(parcelJobDetailsVm => parcelJobDetailsVm.PaymentState, opt => opt.MapFrom(parcelJob => parcelJob.PaymentState))
            .ForMember(parcelJobDetailsVm => parcelJobDetailsVm.Parcel, opt => opt.MapFrom(parcelJob => parcelJob.Parcel))
            .ForMember(parcelJobDetailsVm => parcelJobDetailsVm.DateCreated, opt => opt.MapFrom(parcelJob => parcelJob.DateCreated))
            .ForMember(parcelJobDetailsVm => parcelJobDetailsVm.DateUpdated, opt => opt.MapFrom(parcelJob => parcelJob.DateUpdated));
    }
}