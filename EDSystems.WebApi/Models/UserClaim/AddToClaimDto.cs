using AutoMapper;
using EDSystems.Application.Common.Mappings;
using EDSystems.Application.EDSystems.Commands.MyClaims.AddToClaim;

namespace EDSystems.WebApi.Models.UserClaim.GetClaimList;

public class AddToClaimDto : IMapWith<AddToClaimCommand>
{
    public string Email { get; set; }
    public string ClaimType { get; set; }
    public string ClaimName { get; set; }
    public string ClaimValue { get; set; }

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