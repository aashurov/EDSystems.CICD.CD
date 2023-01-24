using AutoMapper;
using EDSystems.Application.Common.Mappings;
using EDSystems.Domain.Entities;

namespace EDSystems.Application.EDSystems.Queries.UserAccounts.GetUserAccountDetails;

public class UserAccountCurrencyVm : IMapWith<Currency>
{
    public string Name { get; set; }
    public string Code { get; set; }
    public int Number { get; set; }
    public string Country { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Currency, UserAccountCurrencyVm>()
            .ForMember(userAccountCurrencyVm => userAccountCurrencyVm.Name, opt => opt.MapFrom(parcel => parcel.Name))
            .ForMember(userAccountCurrencyVm => userAccountCurrencyVm.Code, opt => opt.MapFrom(parcel => parcel.Code))
            .ForMember(userAccountCurrencyVm => userAccountCurrencyVm.Number, opt => opt.MapFrom(parcel => parcel.Number))
            .ForMember(userAccountCurrencyVm => userAccountCurrencyVm.Country, opt => opt.MapFrom(parcel => parcel.Country));
    }
}