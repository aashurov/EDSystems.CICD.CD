using AutoMapper;
using EDSystems.Application.Common.Mappings;
using EDSystems.Domain.Entities;
using System;

namespace EDSystems.Application.EDSystems.Queries.Accounts.GetAccountDetails;

public class AccountHistoryVm : IMapWith<AccountHistory>
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public bool JobType { get; set; }
    public Account BranchAccount { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime? DateUpdated { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<AccountHistory, AccountHistoryVm>()
            .ForMember(accountHistoryVm => accountHistoryVm.Id, opt => opt.MapFrom(accountHistory => accountHistory.Id))
            .ForMember(accountHistoryVm => accountHistoryVm.Amount, opt => opt.MapFrom(accountHistory => accountHistory.Amount))
            .ForMember(accountHistoryVm => accountHistoryVm.JobType, opt => opt.MapFrom(accountHistory => accountHistory.JobType))
            .ForMember(accountHistoryVm => accountHistoryVm.BranchAccount, opt => opt.MapFrom(accountHistory => accountHistory.BranchAccount))
            .ForMember(accountHistoryVm => accountHistoryVm.DateCreated, opt => opt.MapFrom(accountHistory => accountHistory.DateCreated))
            .ForMember(accountHistoryVm => accountHistoryVm.DateUpdated, opt => opt.MapFrom(accountHistory => accountHistory.DateUpdated));
    }
}