using AutoMapper;
using EDSystems.Application.Authentication.Commands.Tokens.RefreshTokens;
using EDSystems.Application.Interfaces;
using EDSystems.Domain.Entities.UserEntities;
using EDSystems.WebApi.Models.AuthManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EDSystems.WebApi.Controllers;

/// <summary>
/// AuthUser
/// </summary>
[AllowAnonymous]
[Produces("application/json")]
[Route("api/[controller]")]
public class AuthenticationController : BaseController
{
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<Role> _roleManager;

    private readonly IConfiguration _configuration;
    private readonly IMapper _mapper;
    private readonly TokenValidationParameters _tokenValidationParams;
    private readonly IEDSystemsDbContext _iEDSystemsDbContext;
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="userManager"></param>

    /// <param name="configuration"></param>
    /// <param name="mapper"></param>
    /// <param name="tokenValidationParams"></param>
    /// <param name="iEDSystemsDbContext"></param>
    /// <param name="roleManager"></param>

    public AuthenticationController(UserManager<User> userManager, IConfiguration configuration, IMapper mapper, TokenValidationParameters tokenValidationParams, IEDSystemsDbContext iEDSystemsDbContext, RoleManager<Role> roleManager)
    {
        _userManager = userManager;
        _configuration = configuration;
        _mapper = mapper;
        _tokenValidationParams = tokenValidationParams;
        _iEDSystemsDbContext = iEDSystemsDbContext;
        _roleManager = roleManager;
    }

    /// <summary>
    /// Register
    /// </summary>
    /// <returns></returns>
    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] UserRegisterDto request)
    {
        //Validate incoming request
        if (ModelState.IsValid)
        {
            // we need to check than email is allready exciets
            var user_exict = await _userManager.FindByEmailAsync(request.Email);
            if (user_exict != null)
            {
                return BadRequest(new AuthResult()
                {
                    Result = false,
                    Message = new List<string>()
                    {
                        "Email is pisdes"
                    }
                });
            }
            var user = new User
            {
                Email = request.Email,
                UserName = request.Name
            };
            var isCreateAsync = await _userManager.CreateAsync(user, request.Password);
            var isAddToRoleAsync = await _userManager.AddToRoleAsync(user, "Customer");
            string response = "Error";
            if (isCreateAsync.Succeeded)
            {
                var token = await GenerateJwtToken(user);
                return Ok(token);
            }
            else
            {
                response = isCreateAsync.Errors.ToString();
            }

            if (isAddToRoleAsync.Succeeded)
            {
                response = user.Id;
            }
            else
            {
                response = isAddToRoleAsync.Errors.ToString();
            }
        }
        else
        {
            return BadRequest();
        }
        return BadRequest();
    }

    /// <summary>
    /// Login
    /// </summary>
    /// <returns></returns>
    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] UserLoginDto request)
    {
        if (ModelState.IsValid)
        {
            var user_exict = await _userManager.FindByEmailAsync(request.Email);
            if (user_exict == null)
            {
                return BadRequest(new AuthResult()
                {
                    Result = false,
                    Message = new List<string>()
                    {
                        "Такой пользователь не существует."
                    }
                });
            }

            var isCorrect = await _userManager.CheckPasswordAsync(user_exict, request.Password);

            if (!isCorrect)
            {
                return BadRequest(new AuthResult()
                {
                    Result = false,
                    Message = new List<string>()
                    {
                        "Логин или пароль не правильный."
                    }
                });
            }
            else
            {
                var token = await GenerateJwtToken(user_exict);
                return Ok(token);
            }
        }

        return BadRequest(new AuthResult()
        {
            Result = false,
            Message = new List<string>()
                    {
                        "Неизвестная ошибка"
                    }
        });
    }

    /// <summary>
    /// Refresh Token
    /// </summary>
    /// <returns></returns>
    [HttpPost("RefreshToken")]
    public async Task<IActionResult> RefreshToken([FromBody] TokenRequest tokenRequest)
    {
        if (ModelState.IsValid)
        {
            var result = await VerifyAndGenerateToken(tokenRequest);

            if (result == null)
            {
                return BadRequest(new AuthResult()
                {
                    Result = false,
                    Message = new List<string>()
                    {
                        "Неправильный Токен"
                    }
                });
            }
            else
            {
                return Ok(result);
            }

            //var isCorrect = await _userManager.CheckPasswordAsync(user_exict, request.Password);
            //if (!isCorrect)
            //{
            //    return BadRequest(new AuthResult()
            //    {
            //        Result = false,
            //        Message = new List<string>()
            //        {
            //            "Email is pisdes111"
            //        }
            //    });
            //}
            //else
            //{
            //    var token = await GenerateJwtToken(user_exict);
            //    return Ok(token);
            //}
        }

        return BadRequest(new AuthResult()
        {
            Result = false,
            Message = new List<string>()
                    {
                        "Неправильные параметры"
                    }
        });
    }

    private async Task<List<string>> GetUserRole(string UserId)
    {
        CancellationToken cancellationToken = CancellationToken.None;
        var entity = await _userManager.Users
                                        .Include(p => p.UserRoles).ThenInclude(e => e.Role)
                                        .FirstOrDefaultAsync(userDetails => userDetails.Id == UserId, cancellationToken);

        List<string> rolesMasters = new List<string>();
        foreach (var item in entity.UserRoles)
        {
            var entityRole = await _roleManager.FindByIdAsync(item.RoleId);

            rolesMasters.Add(entityRole.Name);
        }
        return rolesMasters;
    }

    private async Task<AuthResult> GenerateJwtToken(User user)
    {
        var jwtTokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(_configuration.GetSection("JwtConfig:Secret").Value);
        var ExpiryTimeFrame = _configuration.GetSection("JwtConfig:ExpiryTimeFrame").Value;
        var claims = await GetAllValidClaim(user);
        ClaimsIdentity Subject = new ClaimsIdentity(claims);

        foreach (var roleName in await _userManager.GetRolesAsync(user))
        {
            Subject.AddClaim(new Claim(ClaimTypes.Role, roleName));
        }

        var tokenDescription = new SecurityTokenDescriptor()
        {
            Subject = Subject,
            Expires = DateTime.UtcNow.Add(TimeSpan.Parse(ExpiryTimeFrame)),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256),
        };

        var token = jwtTokenHandler.CreateToken(tokenDescription);

        var jwtToken = jwtTokenHandler.WriteToken(token);

        var refreshtoken = new RefreshTokenDto
        {
            JwtId = token.Id,
            IsRevoked = false,
            IsUsed = false,
            UserId = user.Id,
            AddedDateTime = DateTime.UtcNow,
            ExpiryDateTime = DateTime.UtcNow.AddMonths(6),
            Token = RandomString(35) + Guid.NewGuid()
        };

        var command = _mapper.Map<RefreshTokenCommand>(refreshtoken);
        await Mediator.Send(command);
        return new AuthResult()
        {
            Token = jwtToken,
            RefreshTokenn = refreshtoken.Token,
            Result = true,
            Message = new List<string>()
                    {
                        "Успешно"
                    }
        };
        //return jwtToken;
    }

    private async Task<List<Claim>> GetAllValidClaim(User user)
    {
        var _options = new IdentityOptions();
        var claims = new List<Claim>()
        {
                new Claim("id", user.Id),
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToUniversalTime().ToString()),
        };
        var userClaims = await _userManager.GetClaimsAsync(user);

        claims.AddRange(userClaims);
        var userRoles = await _userManager.GetRolesAsync(user);

        foreach (var userRole in userRoles)
        {
            var role = await _roleManager.FindByNameAsync(userRole);
            if (role != null)
            {
                claims.Add(new Claim(ClaimTypes.Role, userRole));

                var roleClaims = await _roleManager.GetClaimsAsync(role);
                foreach (var roleClaim in roleClaims)
                {
                    claims.Add(roleClaim);
                }
            }
        }
        return claims;
    }

    private static string RandomString(int length)
    {
        var random = new Random();
        var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, length)
            .Select(x => x[random.Next(x.Length)]).ToArray());
    }

    private async Task<AuthResult> VerifyAndGenerateToken(TokenRequest tokenRequest)
    {
        var jwtTokenHandler = new JwtSecurityTokenHandler();

        try
        {
            // Validation 1 - Validation JWT token format
            _tokenValidationParams.ValidateLifetime = false;
            var tokenInVerification = jwtTokenHandler.ValidateToken(tokenRequest.Token, _tokenValidationParams, out var validatedToken);
            _tokenValidationParams.ValidateLifetime = true;

            // Validation 2 - Validate encryption alg
            if (validatedToken is JwtSecurityToken jwtSecurityToken)
            {
                var result = jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase);

                if (result == false)
                {
                    return null;
                }
            }

            // Validation 3 - validate expiry date
            var utcExpiryDate = long.Parse(tokenInVerification.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Exp).Value);

            var expiryDate = UnixTimeStampToDateTime(utcExpiryDate);

            if (expiryDate > DateTime.UtcNow)
            {
                return new AuthResult()
                {
                    Result = false,
                    Message = new List<string>() {
                        "Token has not yet expired"
                    }
                };
            }

            // validation 4 - validate existence of the token
            var storedToken = await _iEDSystemsDbContext.RefreshToken.FirstOrDefaultAsync(x => x.Token == tokenRequest.RefreshToken);

            if (storedToken == null)
            {
                return new AuthResult()
                {
                    Result = false,
                    Message = new List<string>() {
                        "Token does not exist"
                    }
                };
            }

            // Validation 5 - validate if used
            if (storedToken.IsUsed)
            {
                return new AuthResult()
                {
                    Result = false,
                    Message = new List<string>() {
                        "Token has been used"
                    }
                };
            }

            // Validation 6 - validate if revoked
            if (storedToken.IsRevoked)
            {
                return new AuthResult()
                {
                    Result = false,
                    Message = new List<string>() {
                        "Token has been revoked"
                    }
                };
            }

            // Validation 7 - validate the id
            var jti = tokenInVerification.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti).Value;

            if (storedToken.JwtId != jti)
            {
                return new AuthResult()
                {
                    Result = false,
                    Message = new List<string>() {
                        "Token doesn't match"
                    }
                };
            }

            // Validation 8 - validate stored token expiry date
            if (storedToken.ExpiryDateTime < DateTime.UtcNow)
            {
                return new AuthResult()
                {
                    Result = false,
                    Message = new List<string>() {
                        "Refresh token has expired"
                    }
                };
            }

            // update current token
            CancellationToken cancellationToken = CancellationToken.None;
            storedToken.IsUsed = true;
            _iEDSystemsDbContext.RefreshToken.Update(storedToken);
            await _iEDSystemsDbContext.SaveChangesAsync(cancellationToken);

            // Generate a new token
            var dbUser = await _userManager.FindByIdAsync(storedToken.UserId);
            return await GenerateJwtToken(dbUser);
        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("Lifetime validation failed. The token is expired."))
            {
                return new AuthResult()
                {
                    Result = false,
                    Message = new List<string>() {
                        "Token has expired please re-login"
                    }
                };
            }
            else
            {
                return new AuthResult()
                {
                    Result = false,
                    Message = new List<string>() {
                        "Something went wrong."
                    }
                };
            }
        }
    }

    private DateTime UnixTimeStampToDateTime(long unixTimeStamp)
    {
        var dateTimeVal = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        dateTimeVal = dateTimeVal.AddSeconds(unixTimeStamp).ToUniversalTime();
        return dateTimeVal;
    }
}