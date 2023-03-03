using AutoMapper;
using EDSystems.Application.Common.Mappings;
using EDSystems.Application.EDSystems.Commands.MyClaims.AddToClaim;

namespace EDSystems.WebApi.Models.UserClaim.GetClaimList;

/// <summary>
/// 
/// </summary>
public class AddToClaimDto : IMapWith<AddToClaimCommand>
{
    /// <summary>
    /// 
    /// </summary>
    public string Email { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string ClaimType { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string ClaimName { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string ClaimValue { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public void Mapping(Profile profile)
    {
        profile.CreateMap<AddToClaimDto, AddToClaimCommand>()
           .ForMember(addToClaimCommand => addToClaimCommand.Email,
               options => options.MapFrom(addToClaimDto => addToClaimDto.Email))
           .ForMember(addToClaimCommand => addToClaimCommand.ClaimType,
               options => options.MapFrom(addToClaimDto => addToClaimDto.ClaimType))
           .ForMember(addToClaimCommand => addToClaimCommand.ClaimName,
               options => options.MapFrom(addToClaimDto => addToClaimDto.ClaimName))
           .ForMember(addToClaimCommand => addToClaimCommand.ClaimValue,
               options => options.MapFrom(addToClaimDto => addToClaimDto.ClaimValue));
    }
}