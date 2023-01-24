using AutoMapper;
using EDSystems.Application.Common.Mappings;
using EDSystems.Domain.Entities;
using EDSystems.Domain.Entities.UserEntities;
using System;

namespace EDSystems.Application.EDSystems.Queries.UserAccountHistories.GetUserAccountHistoryList;

public class UserAccountHistoryLookupDto : IMapWith<UserAccountHistory>
{
    public int Id { get; set; }
    public bool JobType { get; set; }
    public Account BranchAccount { get; set; }
    public Parcel Parcel { get; set; }
    public Currency Currency { get; set; }
    public User User { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime? DateUpdated { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UserAccountHistory, UserAccountHistoryLookupDto>()
            .ForMember(userAccountHistoryLookupDto => userAccountHistoryLookupDto.Id, opt => opt.MapFrom(userAccountHistory => userAccountHistory.Id))
            .ForMember(userAccountHistoryLookupDto => userAccountHistoryLookupDto.JobType, opt => opt.MapFrom(userAccountHistory => userAccountHistory.JobType))
            .ForMember(userAccountHistoryLookupDto => userAccountHistoryLookupDto.User, opt => opt.MapFrom(userAccountHistory => userAccountHistory.User))
            .ForMember(userAccountHistoryLookupDto => userAccountHistoryLookupDto.Currency, opt => opt.MapFrom(userAccountHistory => userAccountHistory.Currency))
            .ForMember(userAccountHistoryLookupDto => userAccountHistoryLookupDto.Parcel, opt => opt.MapFrom(userAccountHistory => userAccountHistory.Parcel))
            .ForMember(userAccountHistoryLookupDto => userAccountHistoryLookupDto.DateCreated, opt => opt.MapFrom(userAccountHistory => userAccountHistory.DateCreated))
            .ForMember(userAccountHistoryLookupDto => userAccountHistoryLookupDto.DateUpdated, opt => opt.MapFrom(userAccountHistory => userAccountHistory.DateUpdated));
    }
}