using AutoMapper;
using EDSystems.Application.Common.Mappings;
using EDSystems.Domain.Entities;
using EDSystems.Domain.Entities.UserEntities;
using System;

namespace EDSystems.Application.EDSystems.Queries.AccountsHistory.GetAccountHistoryListWithPagination;

public class AccountHistoryLookupDtoWithPagination : IMapWith<AccountHistory>
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
        profile.CreateMap<AccountHistory, AccountHistoryLookupDtoWithPagination>()
            .ForMember(accountHistoryLookupDto => accountHistoryLookupDto.Id, opt => opt.MapFrom(accountHistory => accountHistory.Id))
            .ForMember(accountHistoryLookupDto => accountHistoryLookupDto.JobType, opt => opt.MapFrom(accountHistory => accountHistory.JobType))
            .ForMember(accountHistoryLookupDto => accountHistoryLookupDto.BranchAccount, opt => opt.MapFrom(accountHistory => accountHistory.BranchAccount))
            .ForMember(accountHistoryLookupDto => accountHistoryLookupDto.Payer, opt => opt.MapFrom(accountHistory => accountHistory.Payer))
            .ForMember(accountHistoryLookupDto => accountHistoryLookupDto.Currency, opt => opt.MapFrom(accountHistory => accountHistory.Currency))
            .ForMember(accountHistoryLookupDto => accountHistoryLookupDto.Parcel, opt => opt.MapFrom(accountHistory => accountHistory.Parcel))
            .ForMember(accountHistoryLookupDto => accountHistoryLookupDto.DateCreated, opt => opt.MapFrom(accountHistory => accountHistory.DateCreated))
            .ForMember(accountHistoryLookupDto => accountHistoryLookupDto.DateUpdated, opt => opt.MapFrom(accountHistory => accountHistory.DateUpdated));
    }
}