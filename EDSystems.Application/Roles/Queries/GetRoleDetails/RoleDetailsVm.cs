using AutoMapper;
using EDSystems.Application.Common.Mappings;
using EDSystems.Domain.Entities.UserEntities;

namespace EDSystems.Application.Roles.Queries.GetRoleDetails;

public class RoleDetailsVm : IMapWith<Role>
{
    public string Id { get; set; }
    public string Name { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Role, RoleDetailsVm>()
            .ForMember(userVm => userVm.Id, opt => opt.MapFrom(customer => customer.Id))
            .ForMember(userVm => userVm.Name, opt => opt.MapFrom(customer => customer.Name));
    }
}