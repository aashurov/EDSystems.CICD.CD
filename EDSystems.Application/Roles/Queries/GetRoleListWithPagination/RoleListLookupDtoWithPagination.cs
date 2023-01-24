using AutoMapper;
using EDSystems.Application.Common.Mappings;
using EDSystems.Domain.Entities.UserEntities;

namespace EDSystems.Application.Roles.Queries.GetRoleListWithPagination;

public class RoleListLookupDtoWithPagination : IMapWith<Role>
{
    public string Id { get; set; }
    public string Name { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Role, RoleListLookupDtoWithPagination>()
            .ForMember(roleDto => roleDto.Id, opt => opt.MapFrom(role => role.Id))
            .ForMember(roleDto => roleDto.Name, opt => opt.MapFrom(role => role.Name));
    }
}