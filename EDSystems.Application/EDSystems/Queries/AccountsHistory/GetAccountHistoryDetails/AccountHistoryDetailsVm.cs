using AutoMapper;
using EDSystems.Application.Common.Mappings;
using EDSystems.Domain.Entities;
using EDSystems.Domain.Entities.UserEntities;
using System;

namespace EDSystems.Application.EDSystems.Queries.AccountsHistory.GetAccountHistoryDetails;

public class AccountHistoryDetailsVm : IMapWith<AccountHistory>
{
    public int Id { get; set; }
    public bool JobType { get; set; }
    public Account BranchAccount { get; set; }
    public Parcel Parcel { get; set; }
    public Currency Currency { get; set; }
    public User Payer { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime? DateUpdated { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<AccountHistory, AccountHistoryDetailsVm>()
            .ForMember(accountHistoryDetailsVm => accountHistoryDetailsVm.Id, opt => opt.MapFrom(accountHistory => accountHistory.Id))
            .ForMember(accountHistoryDetailsVm => accountHistoryDetailsVm.JobType, opt => opt.MapFrom(accountHistory => accountHistory.JobType))
            .ForMember(accountHistoryDetailsVm => accountHistoryDetailsVm.BranchAccount, opt => opt.MapFrom(accountHistory => accountHistory.BranchAccount))
            .ForMember(accountHistoryDetailsVm => accountHistoryDetailsVm.Payer, opt => opt.MapFrom(accountHistory => accountHistory.Payer))
            .ForMember(accountHistoryDetailsVm => accountHistoryDetailsVm.Currency, opt => opt.MapFrom(accountHistory => accountHistory.Currency))
            .ForMember(accountHistoryDetailsVm => accountHistoryDetailsVm.Parcel, opt => opt.MapFrom(accountHistory => accountHistory.Parcel))
            .ForMember(accountHistoryDetailsVm => accountHistoryDetailsVm.DateCreated, opt => opt.MapFrom(accountHistory => accountHistory.DateCreated))
            .ForMember(accountHistoryDetailsVm => accountHistoryDetailsVm.DateUpdated, opt => opt.MapFrom(accountHistory => accountHistory.DateUpdated));
    }
}