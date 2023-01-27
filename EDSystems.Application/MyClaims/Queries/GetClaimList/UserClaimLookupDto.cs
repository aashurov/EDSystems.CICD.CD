using AutoMapper;
using EDSystems.Application.Common.Mappings;
using EDSystems.Domain.IdentityUserEntities;

namespace EDSystems.Application.Claims.Queries.GetClaimList;

public class UserClaimLookupDto : IMapWith<UserClaim>
{
    //public string Id { get; set; }
    public string ClaimType { get; set; }
    public string ClaimName { get; set; }
    public string UserId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UserClaim, UserClaimLookupDto>()
            //.ForMember(claimLookupDto => claimLookupDto.Id, opt => opt.MapFrom(userClaim => userClaim.Id))
            .ForMember(claimLookupDto => claimLookupDto.ClaimType, opt => opt.MapFrom(userClaim => userClaim.ClaimType))
            .ForMember(claimLookupDto => claimLookupDto.UserId, opt => opt.MapFrom(userClaim => userClaim.UserId));
    }
}