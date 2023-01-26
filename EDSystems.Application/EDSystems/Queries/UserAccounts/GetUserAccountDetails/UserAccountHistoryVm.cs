using AutoMapper;
using EDSystems.Application.Common.Mappings;
using EDSystems.Domain.Entities;
using EDSystems.Domain.Entities.UserEntities;
using System;

namespace EDSystems.Application.EDSystems.Queries.UserAccounts.GetUserAccountDetails;

public class UserAccountHistoryVm : IMapWith<UserAccountHistory>
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public bool JobType { get; set; }
    public User User { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime? DateUpdated { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UserAccountHistory, UserAccountHistoryVm>()
            .ForMember(userAccountHistoryVm => userAccountHistoryVm.Id, opt => opt.MapFrom(userAccountHistory => userAccountHistory.Id))
            .ForMember(userAccountHistoryVm => userAccountHistoryVm.Amount, opt => opt.MapFrom(userAccountHistory => userAccountHistory.Amount))
            .ForMember(userAccountHistoryVm => userAccountHistoryVm.JobType, opt => opt.MapFrom(userAccountHistory => userAccountHistory.JobType))
            .ForMember(userAccountHistoryVm => userAccountHistoryVm.User, opt => opt.MapFrom(userAccountHistory => userAccountHistory.User))
            .ForMember(userAccountHistoryVm => userAccountHistoryVm.User, opt => opt.MapFrom(userAccountHistory => userAccountHistory.User))
            .ForMember(userAccountHistoryVm => userAccountHistoryVm.DateCreated, opt => opt.MapFrom(userAccountHistory => userAccountHistory.DateCreated))
            .ForMember(userAccountHistoryVm => userAccountHistoryVm.DateUpdated, opt => opt.MapFrom(userAccountHistory => userAccountHistory.DateUpdated));
    }
}