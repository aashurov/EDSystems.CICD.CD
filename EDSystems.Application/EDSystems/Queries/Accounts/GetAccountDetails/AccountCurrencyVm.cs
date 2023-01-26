using AutoMapper;
using EDSystems.Application.Common.Mappings;
using EDSystems.Domain.Entities;

namespace EDSystems.Application.EDSystems.Queries.Accounts.GetAccountDetails;

public class AccountCurrencyVm : IMapWith<Currency>
{
    public string Name { get; set; }
    public string Code { get; set; }
    public int Number { get; set; }
    public string Country { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Currency, AccountCurrencyVm>()
            .ForMember(AccountCurrencyVm => AccountCurrencyVm.Name, opt => opt.MapFrom(currency => currency.Name))
            .ForMember(AccountCurrencyVm => AccountCurrencyVm.Code, opt => opt.MapFrom(currency => currency.Code))
            .ForMember(AccountCurrencyVm => AccountCurrencyVm.Number, opt => opt.MapFrom(currency => currency.Number))
            .ForMember(AccountCurrencyVm => AccountCurrencyVm.Country, opt => opt.MapFrom(currency => currency.Country));
    }
}