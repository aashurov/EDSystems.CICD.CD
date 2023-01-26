using AutoMapper;
using EDSystems.Application.Common.Mappings;
using EDSystems.Domain.Entities;
using EDSystems.Domain.Entities.UserEntities;
using System;

namespace EDSystems.Application.EDSystems.Queries.UserAccountHistories.GetUserAccountHistoryDetails;

public class UserAccountHistoryDetailsVm : IMapWith<UserAccountHistory>
{
    public int Id { get; set; }
    public bool JobType { get; set; }
    public Parcel Parcel { get; set; }
    public Currency Currency { get; set; }
    public User User { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime? DateUpdated { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UserAccountHistory, UserAccountHistoryDetailsVm>()
            .ForMember(userAccountHistoryDetailsVm => userAccountHistoryDetailsVm.Id, opt => opt.MapFrom(userAccountHistory => userAccountHistory.Id))
            .ForMember(userAccountHistoryDetailsVm => userAccountHistoryDetailsVm.JobType, opt => opt.MapFrom(userAccountHistory => userAccountHistory.JobType))
            .ForMember(userAccountHistoryDetailsVm => userAccountHistoryDetailsVm.User, opt => opt.MapFrom(userAccountHistory => userAccountHistory.User))
            .ForMember(userAccountHistoryDetailsVm => userAccountHistoryDetailsVm.Currency, opt => opt.MapFrom(userAccountHistory => userAccountHistory.Currency))
            .ForMember(userAccountHistoryDetailsVm => userAccountHistoryDetailsVm.Parcel, opt => opt.MapFrom(userAccountHistory => userAccountHistory.Parcel))
            .ForMember(userAccountHistoryDetailsVm => userAccountHistoryDetailsVm.DateCreated, opt => opt.MapFrom(userAccountHistory => userAccountHistory.DateCreated))
            .ForMember(userAccountHistoryDetailsVm => userAccountHistoryDetailsVm.DateUpdated, opt => opt.MapFrom(userAccountHistory => userAccountHistory.DateUpdated));
    }
}