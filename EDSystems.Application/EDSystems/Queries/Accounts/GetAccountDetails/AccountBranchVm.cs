using AutoMapper;
using EDSystems.Application.Common.Mappings;
using EDSystems.Domain.Entities;

namespace EDSystems.Application.EDSystems.Queries.Accounts.GetAccountDetails;

public class AccountBranchVm : IMapWith<Branch>
{
    public string Name { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Branch, AccountBranchVm>()
            .ForMember(accountBranchVm => accountBranchVm.Name, opt => opt.MapFrom(branch => branch.Name))
            .ForMember(accountBranchVm => accountBranchVm.Country, opt => opt.MapFrom(branch => branch.Country))
            .ForMember(accountBranchVm => accountBranchVm.City, opt => opt.MapFrom(branch => branch.City))
            .ForMember(accountBranchVm => accountBranchVm.Address, opt => opt.MapFrom(branch => branch.Address))
            .ForMember(accountBranchVm => accountBranchVm.Email, opt => opt.MapFrom(branch => branch.Email))
            .ForMember(accountBranchVm => accountBranchVm.Phone, opt => opt.MapFrom(branch => branch.Phone));
    }
}