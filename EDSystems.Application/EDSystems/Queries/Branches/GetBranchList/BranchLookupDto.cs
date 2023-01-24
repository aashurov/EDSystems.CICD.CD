using AutoMapper;
using EDSystems.Application.Common.Mappings;
using EDSystems.Domain.Entities;
using System;

namespace EDSystems.Application.EDSystems.Queries.Branches.GetBranchList;

public class BranchLookupDto : IMapWith<Branch>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Country { get; set; }
    public string Code { get; set; }
    public string City { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public DateTime DateCreated { get; set; } = DateTime.Now;
    public DateTime? DateUpdated { get; set; } = DateTime.Now;

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Branch, BranchLookupDto>()
            .ForMember(branchLookupDto => branchLookupDto.Id, opt => opt.MapFrom(branch => branch.Id))
            .ForMember(branchLookupDto => branchLookupDto.Name, opt => opt.MapFrom(branch => branch.Name))
            .ForMember(branchLookupDto => branchLookupDto.Country, opt => opt.MapFrom(branch => branch.Country))
            .ForMember(branchLookupDto => branchLookupDto.Code, opt => opt.MapFrom(branch => branch.Code))
            .ForMember(branchLookupDto => branchLookupDto.City, opt => opt.MapFrom(branch => branch.City))
            .ForMember(branchLookupDto => branchLookupDto.Address, opt => opt.MapFrom(branch => branch.Address))
            .ForMember(branchLookupDto => branchLookupDto.Email, opt => opt.MapFrom(branch => branch.Email))
            .ForMember(branchLookupDto => branchLookupDto.Phone, opt => opt.MapFrom(branch => branch.Phone))
            .ForMember(branchLookupDto => branchLookupDto.DateCreated, opt => opt.MapFrom(branch => branch.DateCreated))
            .ForMember(branchLookupDto => branchLookupDto.DateUpdated, opt => opt.MapFrom(branch => branch.DateUpdated));
    }
}