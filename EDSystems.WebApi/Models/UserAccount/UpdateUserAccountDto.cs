using AutoMapper;
using EDSystems.Application.Common.Mappings;
using EDSystems.Application.EDSystems.Commands.Accounts.UpdateUserAccount;

namespace EDSystems.WebApi.Models.Account;

/// <summary>
///
/// </summary>
public class UpdateUserAccountDto : IMapWith<UpdateUserAccountCommand>
{
    /// <summary>
    /// q
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// q
    /// </summary>
    public string Number { get; set; }
    /// <summary>
    /// q
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// q
    /// </summary>
    public decimal Balance { get; set; }
    /// <summary>
    /// q
    /// </summary>
    public string UserId { get; set; }
    /// <summary>
    /// q
    /// </summary>
    public int CurrencyId { get; set; }

    /// <summary>
    ///
    /// </summary>
    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateUserAccountDto, UpdateUserAccountCommand>()
            .ForMember(updateAccountCommand => updateAccountCommand.Id,
                options => options.MapFrom(updateAccountDto => updateAccountDto.Id))
            .ForMember(updateAccountCommand => updateAccountCommand.Name,
                options => options.MapFrom(updateAccountDto => updateAccountDto.Name))
            .ForMember(updateAccountCommand => updateAccountCommand.Number,
                options => options.MapFrom(updateAccountDto => updateAccountDto.Number))
            .ForMember(updateAccountCommand => updateAccountCommand.Balance,
                options => options.MapFrom(updateAccountDto => updateAccountDto.Balance))
            .ForMember(updateAccountCommand => updateAccountCommand.UserId,
                options => options.MapFrom(updateAccountDto => updateAccountDto.UserId))
            .ForMember(updateAccountCommand => updateAccountCommand.CurrencyId,
                options => options.MapFrom(updateAccountDto => updateAccountDto.CurrencyId));
    }
}