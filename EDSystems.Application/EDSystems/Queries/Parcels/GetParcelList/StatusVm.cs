using AutoMapper;
using EDSystems.Application.Common.Mappings;
using EDSystems.Domain.Entities;

namespace EDSystems.Application.EDSystems.Queries.Parcels.GetParcelList;

public class StatusVm : IMapWith<Status>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Status, StatusVm>()

            .ForMember(parcelBranchDto => parcelBranchDto.Name, opt => opt.MapFrom(parcelBranch => parcelBranch.Name))
            .ForMember(parcelBranchDto => parcelBranchDto.Description, opt => opt.MapFrom(parcelBranch => parcelBranch.Description));
    }
}