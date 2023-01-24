using AutoMapper;
using EDSystems.Application.Common.Mappings;
using EDSystems.Domain.Entities;

namespace EDSystems.Application.EDSystems.Queries.Parcels.GetParcelList;

public class ParcelBranchLookupDto : IMapWith<ParcelBranch>
{
    public int Id { get; set; }
    public Branch ToBranch { get; set; }
    public Branch FromBranch { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<ParcelBranch, ParcelBranchLookupDto>()

            .ForPath(parcelBranchLookupDto => parcelBranchLookupDto.Id, opt => opt.MapFrom(parcelBranch => parcelBranch.Id))
            .ForPath(parcelBranchLookupDto => parcelBranchLookupDto.ToBranch.Address, opt => opt.MapFrom(parcelBranch => parcelBranch.ToBranch.Address))
            .ForPath(parcelBranchLookupDto => parcelBranchLookupDto.ToBranch.City, opt => opt.MapFrom(parcelBranch => parcelBranch.ToBranch.City))
            .ForPath(parcelBranchLookupDto => parcelBranchLookupDto.ToBranch.Country, opt => opt.MapFrom(parcelBranch => parcelBranch.ToBranch.Country))
            .ForPath(parcelBranchLookupDto => parcelBranchLookupDto.ToBranch.Email, opt => opt.MapFrom(parcelBranch => parcelBranch.ToBranch.Email))
            .ForPath(parcelBranchLookupDto => parcelBranchLookupDto.ToBranch.Phone, opt => opt.MapFrom(parcelBranch => parcelBranch.ToBranch.Phone))
            .ForPath(parcelBranchLookupDto => parcelBranchLookupDto.ToBranch.DateCreated, opt => opt.MapFrom(parcelBranch => parcelBranch.ToBranch.DateCreated))
            .ForPath(parcelBranchLookupDto => parcelBranchLookupDto.ToBranch.DateUpdated, opt => opt.MapFrom(parcelBranch => parcelBranch.ToBranch.DateUpdated))

            .ForPath(parcelBranchLookupDto => parcelBranchLookupDto.FromBranch.Address, opt => opt.MapFrom(parcelBranch => parcelBranch.FromBranch.Address))
            .ForPath(parcelBranchLookupDto => parcelBranchLookupDto.FromBranch.City, opt => opt.MapFrom(parcelBranch => parcelBranch.FromBranch.City))
            .ForPath(parcelBranchLookupDto => parcelBranchLookupDto.FromBranch.Country, opt => opt.MapFrom(parcelBranch => parcelBranch.FromBranch.Country))
            .ForPath(parcelBranchLookupDto => parcelBranchLookupDto.FromBranch.Email, opt => opt.MapFrom(parcelBranch => parcelBranch.FromBranch.Email))
            .ForPath(parcelBranchLookupDto => parcelBranchLookupDto.FromBranch.Phone, opt => opt.MapFrom(parcelBranch => parcelBranch.FromBranch.Phone))
            .ForPath(parcelBranchLookupDto => parcelBranchLookupDto.FromBranch.DateCreated, opt => opt.MapFrom(parcelBranch => parcelBranch.FromBranch.DateCreated))
            .ForPath(parcelBranchLookupDto => parcelBranchLookupDto.FromBranch.DateUpdated, opt => opt.MapFrom(parcelBranch => parcelBranch.FromBranch.DateUpdated));
    }
}