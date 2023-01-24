using AutoMapper;
using EDSystems.Application.Common.Mappings;
using EDSystems.Application.Users.Commands.CreateUser;

namespace EDSystems.WebApi.Models.UserManager;

/// <summary>
///
/// </summary>
public class CreateUserDto : IMapWith<CreateUserCommand>
{
    /// <summary>
    ///
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    ///
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    ///
    /// </summary>
    public string UserName { get; set; }

    /// <summary>
    ///
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    ///
    /// </summary>
    public string PhoneNumber { get; set; }

    /// <summary>
    ///
    /// </summary>
    public string Address { get; set; }

    /// <summary>
    ///
    /// </summary>
    public string RoleName { get; set; }

    /// <summary>
    ///
    /// </summary>
    public string PasswordHash { get; set; }

    /// <summary>
    ///
    /// </summary>
    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateUserDto, CreateUserCommand>()
            .ForMember(createUserCommand => createUserCommand.FirstName,
                options => options.MapFrom(createUserDto => createUserDto.FirstName))
            .ForMember(createUserCommand => createUserCommand.LastName,
                options => options.MapFrom(createUserDto => createUserDto.LastName))
            .ForMember(createUserCommand => createUserCommand.UserName,
                options => options.MapFrom(createUserDto => createUserDto.UserName))
            .ForMember(createUserCommand => createUserCommand.Email,
                options => options.MapFrom(createUserDto => createUserDto.Email))
        .ForMember(createUserCommand => createUserCommand.PhoneNumber,
                options => options.MapFrom(createUserDto => createUserDto.PhoneNumber))
         .ForMember(createUserCommand => createUserCommand.RoleName,
                options => options.MapFrom(createUserDto => createUserDto.RoleName))
         .ForMember(createUserCommand => createUserCommand.Address,
                options => options.MapFrom(createUserDto => createUserDto.Address))
        .ForMember(createUserCommand => createUserCommand.PasswordHash,
                options => options.MapFrom(createUserDto => createUserDto.PasswordHash));
    }
}