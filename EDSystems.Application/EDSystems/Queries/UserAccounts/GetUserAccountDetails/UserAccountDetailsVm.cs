using AutoMapper;
using EDSystems.Application.Common.Mappings;
using EDSystems.Domain.Entities;
using EDSystems.Domain.Entities.UserEntities;
using System;
using System.Collections.Generic;

namespace EDSystems.Application.EDSystems.Queries.UserAccounts.GetUserAccountDetails;

public class UserAccountDetailsVm : IMapWith<UserAccount>
{
    public int Id { get; set; }
    public string Number { get; set; }
    public string Name { get; set; }
    public decimal Balance { get; set; }
    public UserAccountCurrencyVm Currency { get; set; }
    public User User { get; set; }
    public ICollection<UserAccountHistoryVm> UserAccountHistory { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime? DateUpdated { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UserAccount, UserAccountDetailsVm>()
            .ForMember(userAccountDetailsVm => userAccountDetailsVm.Id, opt => opt.MapFrom(userAccount => userAccount.Id))
            .ForMember(userAccountDetailsVm => userAccountDetailsVm.Number, opt => opt.MapFrom(userAccount => userAccount.Number))
            .ForMember(userAccountDetailsVm => userAccountDetailsVm.Name, opt => opt.MapFrom(userAccount => userAccount.Name))
            .ForMember(userAccountDetailsVm => userAccountDetailsVm.Balance, opt => opt.MapFrom(userAccount => userAccount.Balance))
            .ForMember(userAccountDetailsVm => userAccountDetailsVm.User, opt => opt.MapFrom(userAccount => userAccount.User))
            .ForMember(userAccountDetailsVm => userAccountDetailsVm.Currency, opt => opt.MapFrom(userAccount => userAccount.Currency))
            .ForMember(userAccountDetailsVm => userAccountDetailsVm.DateCreated, opt => opt.MapFrom(userAccount => userAccount.DateCreated))
            .ForMember(userAccountDetailsVm => userAccountDetailsVm.DateUpdated, opt => opt.MapFrom(userAccount => userAccount.DateUpdated));
    }
}