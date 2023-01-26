using AutoMapper;
using EDSystems.Application.Common.Mappings;
using EDSystems.Application.Users.Commands.DeleteFromRole;
using System.ComponentModel.DataAnnotations;

namespace EDSystems.WebApi.Models.UserManager;

/// <summary>
///
/// </summary>
public class DeleteFromRoleDto : IMapWith<DeleteFromRoleCommand>
{
    /// <summary>
    ///
    /// </summary>
    [Required]
    public string RoleId { get; set; }

    /// <summary>
    ///
    /// </summary>
    [Required]
    public string UserId { get; set; }

    /// <summary>
    ///
    /// </summary>
    public void Mapping(Profile profile)
    {
        profile.CreateMap<DeleteFromRoleDto, DeleteFromRoleCommand>()
            .ForMember(deleteFromRoleCommand => deleteFromRoleCommand.UserId,
                options => options.MapFrom(deleteFromRoleDto => deleteFromRoleDto.UserId))
            .ForMember(deleteFromRoleCommand => deleteFromRoleCommand.RoleId,
                options => options.MapFrom(deleteFromRoleDto => deleteFromRoleDto.RoleId));
    }
}