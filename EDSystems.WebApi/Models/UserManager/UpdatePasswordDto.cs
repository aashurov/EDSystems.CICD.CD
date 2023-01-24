using AutoMapper;
using EDSystems.Application.Common.Mappings;
using EDSystems.Application.Users.Commands.UpdatePassword;

namespace EDSystems.WebApi.Models.UserManager;

/// <summary>
///
/// </summary>
public class UpdatePasswordDto : IMapWith<UpdatePasswordCommand>
{
    /// <summary>
    ///
    /// </summary>
    public string UserId { get; set; }

    /// <summary>
    ///
    /// </summary>
    public string PasswordHash { get; set; }

    /// <summary>
    ///
    /// </summary>
    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdatePasswordDto, UpdatePasswordCommand>()
            .ForMember(updateBranchCommand => updateBranchCommand.UserId,
                options => options.MapFrom(updateBranchDto => updateBranchDto.UserId))
            .ForMember(updateBranchCommand => updateBranchCommand.PasswordHash,
                options => options.MapFrom(updateBranchDto => updateBranchDto.PasswordHash));
    }
}