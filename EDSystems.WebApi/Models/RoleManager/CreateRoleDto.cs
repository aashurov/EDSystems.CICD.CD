using AutoMapper;
using EDSystems.Application.Common.Mappings;
using EDSystems.Application.Roles.Commands.CreateRole;
using System.ComponentModel.DataAnnotations;

namespace EDSystems.WebApi.Models.RoleManager;

/// <summary>
///
/// </summary>
public class CreateRoleDto : IMapWith<CreateRoleCommand>
{
    /// <summary>
    ///
    /// </summary>
    [Required]
    public string Name { get; set; }

    /// <summary>
    ///
    /// </summary>

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateRoleDto, CreateRoleCommand>()
            .ForMember(createRoleCommand => createRoleCommand.Name,
                options => options.MapFrom(createRoleDto => createRoleDto.Name));
    }
}