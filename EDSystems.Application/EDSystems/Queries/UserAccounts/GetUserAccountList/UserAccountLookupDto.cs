using AutoMapper;
using EDSystems.Application.Common.Mappings;
using EDSystems.Domain.Entities;
using EDSystems.Domain.Entities.UserEntities;
using System;
using System.Collections.Generic;

namespace EDSystems.Application.EDSystems.Queries.UserAccounts.GetUserAccountList;

public class UserAccountLookupDto : IMapWith<UserAccount>
{
    public int Id { get; set; }
    public string Number { get; set; }
    public string Name { get; set; }
    public decimal Balance { get; set; }
    public User User { get; set; }
    public Currency Currency { get; set; }
    public ICollection<AccountHistory> AccountHistory { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime? DateUpdated { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UserAccount, UserAccountLookupDto>()
            .ForMember(userAccountHistory => userAccountHistory.Id, opt => opt.MapFrom(userAccount => userAccount.Id))
            .ForMember(userAccountHistory => userAccountHistory.Number, opt => opt.MapFrom(userAccount => userAccount.Number))
            .ForMember(userAccountHistory => userAccountHistory.Name, opt => opt.MapFrom(userAccount => userAccount.Name))
            .ForMember(userAccountHistory => userAccountHistory.Balance, opt => opt.MapFrom(userAccount => userAccount.Balance))
            .ForMember(userAccountHistory => userAccountHistory.User, opt => opt.MapFrom(userAccount => userAccount.User))
            .ForMember(userAccountHistory => userAccountHistory.Currency, opt => opt.MapFrom(userAccount => userAccount.Currency))
            .ForMember(userAccountHistory => userAccountHistory.DateCreated, opt => opt.MapFrom(userAccount => userAccount.DateCreated))
            .ForMember(userAccountHistory => userAccountHistory.DateUpdated, opt => opt.MapFrom(userAccount => userAccount.DateUpdated));
    }
}