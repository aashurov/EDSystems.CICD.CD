using AutoMapper;
using EDSystems.Application.Common.Mappings;
using EDSystems.Domain.Entities;

namespace EDSystems.Application.EDSystems.Queries.Parcels.GetParcelDetails
{
    public class ParcelBranchVm : IMapWith<Branch>
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string Code { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Branch, ParcelBranchVm>()
             .ForMember(parcelBranchVm => parcelBranchVm.Name, opt => opt.MapFrom(branch => branch.Name))
             .ForMember(parcelBranchVm => parcelBranchVm.Country, opt => opt.MapFrom(branch => branch.Country))
             .ForMember(parcelBranchVm => parcelBranchVm.Code, opt => opt.MapFrom(branch => branch.Code))
             .ForMember(parcelBranchVm => parcelBranchVm.City, opt => opt.MapFrom(branch => branch.City))
             .ForMember(parcelBranchVm => parcelBranchVm.Address, opt => opt.MapFrom(branch => branch.Address))
             .ForMember(parcelBranchVm => parcelBranchVm.Email, opt => opt.MapFrom(branch => branch.Email))
             .ForMember(parcelBranchVm => parcelBranchVm.Phone, opt => opt.MapFrom(branch => branch.Phone));
        }
    }
}