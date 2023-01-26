using AutoMapper;
using EDSystems.Application.Common.Mappings;
using EDSystems.Domain.Entities;
using System;
using System.Collections.Generic;

namespace EDSystems.Application.EDSystems.Queries.Accounts.GetAccountDetails;

public class AccountDetailsVm : IMapWith<Account>
{
    public int Id { get; set; }
    public string Number { get; set; }
    public string Name { get; set; }
    public decimal Balance { get; set; }
    public AccountBranchVm Branch { get; set; }
    public AccountCurrencyVm Currency { get; set; }
    public ICollection<AccountHistoryVm> AccountHistory { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime? DateUpdated { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Account, AccountDetailsVm>()
            .ForMember(accountDetailsVm => accountDetailsVm.Id, opt => opt.MapFrom(account => account.Id))
            .ForMember(accountDetailsVm => accountDetailsVm.Number, opt => opt.MapFrom(account => account.Number))
            .ForMember(accountDetailsVm => accountDetailsVm.Name, opt => opt.MapFrom(account => account.Name))
            .ForMember(accountDetailsVm => accountDetailsVm.Balance, opt => opt.MapFrom(account => account.Balance))
            .ForMember(accountDetailsVm => accountDetailsVm.Branch, opt => opt.MapFrom(account => account.Branch))
            .ForMember(accountDetailsVm => accountDetailsVm.Currency, opt => opt.MapFrom(account => account.Currency))
            .ForMember(accountDetailsVm => accountDetailsVm.AccountHistory, opt => opt.MapFrom(account => account.AccountHistory))
            .ForMember(accountDetailsVm => accountDetailsVm.DateCreated, opt => opt.MapFrom(account => account.DateCreated))
            .ForMember(accountDetailsVm => accountDetailsVm.DateUpdated, opt => opt.MapFrom(account => account.DateUpdated));
    }
}