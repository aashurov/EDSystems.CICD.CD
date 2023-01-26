using AutoMapper;
using EDSystems.Application.Claims.Queries.GetClaimList;
using EDSystems.Application.Common.Mappings;

namespace EDSystems.WebApi.Models.UserClaim.GetClaimList;

public class GetUserClaimDto : IMapWith<GetUserClaimListQuery>
{
    public string Id { get; set; }
    public string Email { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<GetUserClaimListQuery, GetUserClaimDto>()
            .ForMember(getUserClaimListQuery => getUserClaimListQuery.Id, opt => opt.MapFrom(getUserClaimListQuery => getUserClaimListQuery.Id))
            .ForMember(getUserClaimListQuery => getUserClaimListQuery.Email, opt => opt.MapFrom(getUserClaimListQuery => getUserClaimListQuery.Email));
    }
}