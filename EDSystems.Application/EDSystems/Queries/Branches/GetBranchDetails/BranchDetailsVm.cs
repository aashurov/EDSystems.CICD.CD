using AutoMapper;
using EDSystems.Application.Common.Mappings;
using EDSystems.Domain.Entities;
using System;

namespace EDSystems.Application.EDSystems.Queries.Branches.GetBranchDetails;

public class BranchDetailsVm : IMapWith<Plan>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Country { get; set; }
    public string Code { get; set; }
    public string City { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime? DateUpdated { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Branch, BranchDetailsVm>()
            .ForMember(branchDetailsVm => branchDetailsVm.Id, opt => opt.MapFrom(branch => branch.Id))
            .ForMember(branchDetailsVm => branchDetailsVm.Name, opt => opt.MapFrom(branch => branch.Name))
            .ForMember(branchDetailsVm => branchDetailsVm.Country, opt => opt.MapFrom(branch => branch.Country))
            .ForMember(branchDetailsVm => branchDetailsVm.Code, opt => opt.MapFrom(branch => branch.Code))
            .ForMember(branchDetailsVm => branchDetailsVm.City, opt => opt.MapFrom(branch => branch.City))
            .ForMember(branchDetailsVm => branchDetailsVm.Address, opt => opt.MapFrom(branch => branch.Address))
            .ForMember(branchDetailsVm => branchDetailsVm.Email, opt => opt.MapFrom(branch => branch.Email))
            .ForMember(branchDetailsVm => branchDetailsVm.Phone, opt => opt.MapFrom(branch => branch.Phone))
            .ForMember(branchDetailsVm => branchDetailsVm.DateCreated, opt => opt.MapFrom(branch => branch.DateCreated))
            .ForMember(branchDetailsVm => branchDetailsVm.DateUpdated, opt => opt.MapFrom(branch => branch.DateUpdated));
    }
}