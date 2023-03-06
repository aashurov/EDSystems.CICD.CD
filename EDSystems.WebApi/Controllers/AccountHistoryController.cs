﻿using AutoMapper;
using EDSystems.Application.EDSystems.Queries.AccountsHistory.GetAccountHistoryDetails;
using EDSystems.Application.EDSystems.Queries.AccountsHistory.GetAccountHistoryList;
using EDSystems.Application.EDSystems.Queries.AccountsHistory.GetAccountHistoryListWithPagination;
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
public class AccountHistoryController : BaseController
{
    private readonly IMapper _mapper;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="mapper"></param>
    public AccountHistoryController(IMapper mapper) => _mapper = mapper;

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
    public async Task<ActionResult<AccountHistoryListVm>> GetAll()
    {
        var query = new GetAccountHistoryListQuery
        {
            //UserId = UserId
        };
        var vm = await Mediator.Send(query);
        return Ok(vm);
    }

    /// <summary>
    /// Get the list of branches with pagination
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
    public async Task<ActionResult<AccountHistoryListVm>> GetAllWithPagination(int PageNumber, int PageSize)
    {
        var query = new GetAccountHistoryListWithPaginationQuery
        {
            PageNumber = PageNumber,
            PageSize = PageSize
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
    public async Task<ActionResult<AccountHistoryDetailsVm>> Get(int Id)
    {
        var query = new GetAccountHistoryDetailsQuery
        {
            Id = Id
        };
        var vm = await Mediator.Send(query);
        return Ok(vm);
    }

    ///// <summary>
    ///// Create Branch
    ///// </summary>
    ///// <remarks>
    ///// </remarks>
    ///// <returns>
    ///// Return Id (int)
    ///// </returns>
    ///// <param name="createNoteDto">CreateBranchDto object</param>
    ///// <responce code="200">Success</responce>
    ///// <responce code="401">If the user is unauthorized</responce>
    //[HttpPost]
    ////[Authorize]
    //[ProducesResponseType(StatusCodes.Status200OK)]
    //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
    //public async Task<ActionResult<Guid>> Create([FromBody] CreateAccountDto createNoteDto)
    //{
    //    var command = _mapper.Map<CreateAccountCommand>(createNoteDto);
    //    var accountId = await Mediator.Send(command);
    //    return Ok(accountId);
    //}

    ///// <summary>
    ///// Update Branch by Id
    ///// </summary>
    ///// <param name="updateAccountDto"></param>
    ///// <returns></returns>
    //[HttpPut]
    ////[Authorize]
    //[ProducesResponseType(StatusCodes.Status204NoContent)]
    //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
    //public async Task<IActionResult> Update([FromBody] UpdateAccountDto updateAccountDto)
    //{
    //    var command = _mapper.Map<UpdateAccountCommand>(updateAccountDto);
    //    await Mediator.Send(command);
    //    return NoContent();
    //}

    ///// <summary>
    ///// Delete Branch by Id
    ///// </summary>
    ///// <remarks>
    ///// </remarks>
    ///// <param name="Id">Id of the Branch</param>
    ///// <returns>
    ///// Returns NoContent
    ///// </returns>
    ///// <responce code="204">Success</responce>
    ///// <responce code="401">If the user is unauthorized</responce>
    //[HttpDelete("{Id}")]
    ////[Authorize]
    //[ProducesResponseType(StatusCodes.Status204NoContent)]
    //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
    //public async Task<IActionResult> Delete(int Id)
    //{
    //    var query = new DeleteAccountCommand
    //    {
    //        Id = Id
    //    };
    //    await Mediator.Send(query);
    //    return NoContent();
    //}
}