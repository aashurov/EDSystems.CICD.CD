using AutoMapper;
using EDSystems.Application.Common.Mappings;
using EDSystems.Application.EDSystems.Queries.Accounts.GetAccountList;
using EDSystems.Domain.Entities;
using System;
using System.Collections.Generic;

namespace EDSystems.Application.EDSystems.Queries.Accounts.GetAccountListWithPagination;

public class AccountLookupDtoWithPagination : IMapWith<Account>
{
    public int Id { get; set; }
    public string Number { get; set; }
    public string Name { get; set; }
    public decimal Balance { get; set; }
    public Branch Branch { get; set; }
    public Currency Currency { get; set; }
    public ICollection<AccountHistory> AccountHistory { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime? DateUpdated { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Account, AccountLookupDto>()
            .ForMember(accountLookupDto => accountLookupDto.Id, opt => opt.MapFrom(account => account.Id))
            .ForMember(accountLookupDto => accountLookupDto.Number, opt => opt.MapFrom(account => account.Number))
            .ForMember(accountLookupDto => accountLookupDto.Name, opt => opt.MapFrom(account => account.Name))
            .ForMember(accountLookupDto => accountLookupDto.Balance, opt => opt.MapFrom(account => account.Balance))
            .ForMember(accountLookupDto => accountLookupDto.Branch, opt => opt.MapFrom(account => account.Branch))
            .ForMember(accountLookupDto => accountLookupDto.Currency, opt => opt.MapFrom(account => account.Currency))
            .ForMember(accountLookupDto => accountLookupDto.AccountHistory, opt => opt.MapFrom(account => account.AccountHistory))
            .ForMember(accountLookupDto => accountLookupDto.DateCreated, opt => opt.MapFrom(account => account.DateCreated))
            .ForMember(accountLookupDto => accountLookupDto.DateUpdated, opt => opt.MapFrom(account => account.DateUpdated));
    }
}