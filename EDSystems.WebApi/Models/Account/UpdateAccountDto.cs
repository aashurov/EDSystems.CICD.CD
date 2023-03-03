﻿using AutoMapper;
using EDSystems.Application.Common.Mappings;
using EDSystems.Application.EDSystems.Commands.Accounts.UpdateAccount;

namespace EDSystems.WebApi.Models.Account;

/// <summary>
///
/// </summary>
public class UpdateAccountDto : IMapWith<UpdateAccountCommand>
{
    /// <summary>
    /// 
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string Number { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public decimal Balance { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int BranchId { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int CurrencyId { get; set; }

    /// <summary>
    ///
    /// </summary>
    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateAccountDto, UpdateAccountCommand>()
            .ForMember(updateAccountCommand => updateAccountCommand.Id,
                options => options.MapFrom(updateAccountDto => updateAccountDto.Id))
            .ForMember(updateAccountCommand => updateAccountCommand.Name,
                options => options.MapFrom(updateAccountDto => updateAccountDto.Name))
            .ForMember(updateAccountCommand => updateAccountCommand.Number,
                options => options.MapFrom(updateAccountDto => updateAccountDto.Number))
            .ForMember(updateAccountCommand => updateAccountCommand.Balance,
                options => options.MapFrom(updateAccountDto => updateAccountDto.Balance))
            .ForMember(updateAccountCommand => updateAccountCommand.BranchId,
                options => options.MapFrom(updateAccountDto => updateAccountDto.BranchId))
            .ForMember(updateAccountCommand => updateAccountCommand.CurrencyId,
                options => options.MapFrom(updateAccountDto => updateAccountDto.CurrencyId));
    }
}