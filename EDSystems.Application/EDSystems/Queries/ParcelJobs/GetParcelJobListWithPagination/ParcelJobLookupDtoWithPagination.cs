using AutoMapper;
using EDSystems.Application.Common.Mappings;
using EDSystems.Domain.Entities;
using EDSystems.Domain.Entities.UserEntities;
using System;
using System.Collections.Generic;

namespace EDSystems.Application.EDSystems.Queries.ParcelJobs.GetParcelJobListWithPagination;

public class ParcelJobLookupDtoWithPagination : IMapWith<ParcelJob>
{
    public int Id { get; set; }

    public decimal Cost { get; set; }
    public ICollection<User> Courier { get; set; }
    public string JobType { get; set; }
    public Parcel Parcel { get; set; }

    //zabor dostavka
    public bool PaymentState { get; set; } //zabor dostavka

    public DateTime DateCreated { get; set; } = DateTime.Now;
    public DateTime? DateUpdated { get; set; } = DateTime.Now;

    public void Mapping(Profile profile)
    {
        profile.CreateMap<ParcelJob, ParcelJobLookupDtoWithPagination>()
            .ForMember(parcelJobLookupDto => parcelJobLookupDto.Id, opt => opt.MapFrom(parcelJob => parcelJob.Id))
            .ForMember(parcelJobLookupDto => parcelJobLookupDto.Cost, opt => opt.MapFrom(parcelJob => parcelJob.Cost))
            .ForMember(parcelJobLookupDto => parcelJobLookupDto.Courier, opt => opt.MapFrom(parcelJob => parcelJob.Courier))
            .ForMember(parcelJobLookupDto => parcelJobLookupDto.JobType, opt => opt.MapFrom(parcelJob => parcelJob.JobType))
            .ForMember(parcelJobLookupDto => parcelJobLookupDto.PaymentState, opt => opt.MapFrom(parcelJob => parcelJob.PaymentState))
            .ForMember(parcelJobLookupDto => parcelJobLookupDto.Parcel, opt => opt.MapFrom(parcelJob => parcelJob.Parcel))
            .ForMember(parcelJobLookupDto => parcelJobLookupDto.DateCreated, opt => opt.MapFrom(parcelJob => parcelJob.DateCreated))
            .ForMember(parcelJobLookupDto => parcelJobLookupDto.DateUpdated, opt => opt.MapFrom(parcelJob => parcelJob.DateUpdated));
    }
}