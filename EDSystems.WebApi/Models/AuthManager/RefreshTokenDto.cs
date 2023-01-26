using AutoMapper;
using EDSystems.Application.Authentication.Commands.Tokens.RefreshTokens;
using EDSystems.Application.Common.Mappings;

namespace EDSystems.WebApi.Models.AuthManager
{
    /// <summary>
    ///
    /// </summary>
    public class RefreshTokenDto : IMapWith<RefreshTokenCommand>
    {
        /// <summary>
        ///
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string JwtId { get; set; }

        /// <summary>
        ///
        /// </summary>
        public bool IsUsed { get; set; }

        /// <summary>
        ///
        /// </summary>
        public bool IsRevoked { get; set; }

        /// <summary>
        ///
        /// </summary>
        public DateTime AddedDateTime { get; set; }

        /// <summary>
        ///
        /// </summary>
        public DateTime ExpiryDateTime { get; set; }

        /// <summary>
        ///
        /// </summary>
        public void Mapping(Profile profile)
        {
            profile.CreateMap<RefreshTokenDto, RefreshTokenCommand>()
                .ForMember(refreshTokenCommand => refreshTokenCommand.Token,
                    options => options.MapFrom(refreshTokenDto => refreshTokenDto.Token))
                .ForMember(refreshTokenCommand => refreshTokenCommand.UserId,
                    options => options.MapFrom(refreshTokenDto => refreshTokenDto.UserId))
                .ForMember(refreshTokenCommand => refreshTokenCommand.JwtId,
                    options => options.MapFrom(refreshTokenDto => refreshTokenDto.JwtId))
                .ForMember(refreshTokenCommand => refreshTokenCommand.IsRevoked,
                    options => options.MapFrom(refreshTokenDto => refreshTokenDto.IsRevoked))
                .ForMember(refreshTokenCommand => refreshTokenCommand.AddedDateTime,
                    options => options.MapFrom(refreshTokenDto => refreshTokenDto.AddedDateTime))
                .ForMember(refreshTokenCommand => refreshTokenCommand.ExpiryDateTime,
                    options => options.MapFrom(refreshTokenDto => refreshTokenDto.ExpiryDateTime))
                ;
        }
    }
}