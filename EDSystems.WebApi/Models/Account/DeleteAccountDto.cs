using AutoMapper;
using EDSystems.Application.Common.Mappings;
using EDSystems.Application.EDSystems.Commands.Accounts.DeleteAccount;
using System.ComponentModel.DataAnnotations;

namespace EDSystems.WebApi.Models.Account;

/// <summary>
///
/// </summary>
public class DeleteAccountDto : IMapWith<DeleteAccountCommand>
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
        profile.CreateMap<DeleteAccountDto, DeleteAccountCommand>()
            .ForMember(deleteAccountCommand => deleteAccountCommand.Id,
                options => options.MapFrom(deleteAccountDto => deleteAccountDto.Id));
    }
}