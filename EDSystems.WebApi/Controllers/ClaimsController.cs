using AutoMapper;
using EDSystems.Application.Claims.Queries.GetClaimList;
using EDSystems.Application.EDSystems.Commands.MyClaims.AddToClaim;
using EDSystems.WebApi.Models.UserClaim.GetClaimList;
using Microsoft.AspNetCore.Mvc;

namespace EDSystems.WebApi.Controllers;

/// <summary>
/// User Manager
/// </summary>
//[Authorize(Roles = "Administrator")]
//[Produces("application/json")]
[Route("api/[controller]")]
[ApiController]
public class ClaimsController : BaseController
{
    private readonly IMapper _mapper;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="mapper"></param>
    public ClaimsController(IMapper mapper) => _mapper = mapper;

    /// <summary>
    /// Get the lists of Claims
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// GET /Claims
    /// </remarks>
    /// <returns>
    /// Return UserListVm
    /// </returns>
    /// <responce code="200">Success</responce>
    /// <responce code="401">If the user is unauthorized</responce>
    [HttpPost]
    //[Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<UserClaimListVm>> GetAll([FromBody] GetUserClaimDto getUserClaimDto)
    {
        var query = new GetUserClaimListQuery
        {
            Email = getUserClaimDto.Email
        };
        var vm = await Mediator.Send(query);
        return Ok(vm);
    }

    /// <summary>
    /// Get the lists of Claims
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// GET /Claims
    /// </remarks>
    /// <returns>
    /// Return UserListVm
    /// </returns>
    /// <responce code="200">Success</responce>
    /// <responce code="401">If the user is unauthorized</responce>
    [HttpPost("AddToClaim")]
    //[Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<UserClaimListVm>> AddToClaim([FromBody] AddToClaimDto addToClaimDto)
    {
        var query = new AddToClaimCommand
        {
            Email = addToClaimDto.Email,
            ClaimName = addToClaimDto.ClaimName,
            ClaimValue = addToClaimDto.ClaimValue
        };
        var vm = await Mediator.Send(query);
        return Ok(vm);
    }
}