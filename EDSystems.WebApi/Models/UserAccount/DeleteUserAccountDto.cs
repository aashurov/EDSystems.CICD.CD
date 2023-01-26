using AutoMapper;
using EDSystems.Application.Common.Mappings;
using EDSystems.Application.EDSystems.Commands.Accounts.DeleteUserAccount;
using System.ComponentModel.DataAnnotations;

namespace EDSystems.WebApi.Models.UserAccount;

/// <summary>
///
/// </summary>
public class DeleteUserAccountDto : IMapWith<DeleteUserAccountCommand>
{
    /// <summary>
    ///
    /// </summary>
    [Required]
    public IEnumerable<int> Id { get; set; }

    /// <summary>
    ///
    /// </summary>
    public void Mapping(Profile profile)
    {
        profile.CreateMap<DeleteUserAccountDto, DeleteUserAccountCommand>()
            .ForMember(deleteAccountCommand => deleteAccountCommand.Id,
                options => options.MapFrom(deleteAccountDto => deleteAccountDto.Id));
    }
}