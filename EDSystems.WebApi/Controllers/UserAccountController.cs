using AutoMapper;
using EDSystems.Application.EDSystems.Commands.Accounts.CreateAccount;
using EDSystems.Application.EDSystems.Commands.Accounts.DeleteUserAccount;
using EDSystems.Application.EDSystems.Commands.Accounts.UpdateUserAccount;
using EDSystems.Application.EDSystems.Queries.UserAccounts.GetUserAccountDetails;
using EDSystems.Application.EDSystems.Queries.UserAccounts.GetUserAccountList;
using EDSystems.Application.EDSystems.Queries.UserAccounts.GetUserAccountListWithPagination;
using EDSystems.WebApi.Models.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EDSystems.WebApi.Controllers;

/// <summary>
/// Accounts
/// </summary>

[Authorize(Roles = "Administrator")]
//[Authorize(Policy = "OnlyForLondon")]
[Produces("application/json")]
[Route("api/[controller]")]
public class UserAccountController : BaseController
{
    private readonly IMapper _mapper;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="mapper"></param>
    public UserAccountController(IMapper mapper) => _mapper = mapper;

    /// <summary>
    /// Get the list of branches
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// GET /note
    /// </remarks>
    /// <returns>
    /// Return BranchListVm
    /// </returns>
    /// <responce code="200">Success</responce>
    /// <responce code="401">If the user is unauthorized</responce>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<UserAccountListVm>> GetAll()
    {
        var query = new GetUserAccountListQuery
        {
            //UserId = UserId
        };
        var vm = await Mediator.Send(query);
        return Ok(vm);
    }

    /// <summary>
    /// Get the list of branches WithPagination
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// GET /note
    /// </remarks>
    /// <returns>
    /// Return BranchListVm
    /// </returns>
    /// <responce code="200">Success</responce>
    /// <responce code="401">If the user is unauthorized</responce>
    [HttpGet("WithPagination")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<UserAccountListVmWithPagination>> GetAllWithPagination()
    {
        var query = new GetUserAccountListWithPaginationQuery
        {
            //UserId = UserId
        };
        var vm = await Mediator.Send(query);
        return Ok(vm);
    }

    /// <summary>
    /// Get Branch by Id
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="Id">Branch Id (int)</param>
    /// <returns>
    /// Return BranchDetailsVm
    /// </returns>
    /// <responce code="200">Success</responce>
    /// <responce code="401">If the user is unauthorized</responce>
    [HttpGet("{Id}")]
    //[Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<UserAccountDetailsVm>> Get(int Id)
    {
        var query = new GetUserAccountDetailsQuery
        {
            Id = Id
        };
        var vm = await Mediator.Send(query);
        return Ok(vm);
    }

    /// <summary>
    /// Create Branch
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <returns>
    /// Return Id (int)
    /// </returns>
    /// <param name="createUserAccountDto">CreateUserAccountDto object</param>
    /// <responce code="200">Success</responce>
    /// <responce code="401">If the user is unauthorized</responce>
    [HttpPost]
    //[Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateUserAccountDto createUserAccountDto)
    {
        var command = _mapper.Map<CreateUserAccountCommand>(createUserAccountDto);
        var accountId = await Mediator.Send(command);
        return Ok(accountId);
    }

    /// <summary>
    /// Update User Account by Id
    /// </summary>
    /// <param name="updateUserAccountDto"></param>
    /// <returns></returns>
    [HttpPut]
    //[Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Update([FromBody] UpdateUserAccountDto updateUserAccountDto)
    {
        var command = _mapper.Map<UpdateUserAccountCommand>(updateUserAccountDto);
        await Mediator.Send(command);
        return NoContent();
    }

    /// <summary>
    /// Delete Branch by Id
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="Id">Id of the Branch</param>
    /// <returns>
    /// Returns NoContent
    /// </returns>
    /// <responce code="204">Success</responce>
    /// <responce code="401">If the user is unauthorized</responce>
    [HttpDelete("{Id}")]
    //[Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Delete(int Id)
    {
        var query = new DeleteUserAccountCommand
        {
            Id = Id
        };
        await Mediator.Send(query);
        return NoContent();
    }
}