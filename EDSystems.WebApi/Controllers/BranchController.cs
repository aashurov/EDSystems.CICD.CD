using Amazon.S3.Model;
using AutoMapper;
using EDSystems.Application.EDSystems.Commands.Branches.CreateBranch;
using EDSystems.Application.EDSystems.Commands.Branches.DeleteBranch;
using EDSystems.Application.EDSystems.Commands.Branches.DeleteBranches;
using EDSystems.Application.EDSystems.Commands.Branches.UpdateBranch;
using EDSystems.Application.EDSystems.Queries.Branches.GetBranchDetails;
using EDSystems.Application.EDSystems.Queries.Branches.GetBranchList;
using EDSystems.Application.EDSystems.Queries.Branches.GetBranchListWithPagination;
using EDSystems.WebApi.Models.Branches;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EDSystems.WebApi.Controllers;

/// <summary>
/// Branches
/// </summary>

//[Authorize(Roles = "Administrator")]
//[Authorize(Policy = "CanAddBranch")]
[Produces("application/json")]
[Route("api/[controller]")]
public class BranchController : BaseController
{
    private readonly IMapper _mapper;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="mapper"></param>
    public BranchController(IMapper mapper) => _mapper = mapper;

    /// <summary>
    /// Get the list of branches
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// GET api/Branch
    /// </remarks>
    /// <returns>
    /// Return BranchListVm
    /// </returns>
    /// <responce code="200">Success</responce>
    /// <responce code="401">If the user is unauthorized</responce>
#if DEBUG
    [ApiExplorerSettings(IgnoreApi = true)]
#else
    [ApiExplorerSettings(IgnoreApi = true)]
#endif
    [HttpGet]
    [Authorize(Policy = "CanGetAllBranches")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<BranchListVm>> GetAll()
    {
        var query = new GetBranchListQuery
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
    /// GET api/Branch
    /// </remarks>
    /// <returns>
    /// Return BranchListVm
    /// </returns>
    /// <responce code="200">Success</responce>
    /// <responce code="401">If the user is unauthorized</responce>
    /// ("WithPagination")
    [HttpGet("WithPagination")]
    [Authorize(Policy = "CanGetAllBranchesWithPagination")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<BranchListVmWithPagination>> GetAllWithPagination(int PageNumber, int PageSize)
    {
        var query = new GetBranchListWithPaginationQuery
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
    [Authorize(Policy = "CanGetBranchDetails")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<BranchDetailsVm>> Get(int Id)
    {
        var query = new GetBranchDetailsQuery
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
    /// <param name="createNoteDto">CreateBranchDto object</param>
    /// <responce code="200">Success</responce>
    /// <responce code="401">If the user is unauthorized</responce>
    [HttpPost]
    //[Authorize]
    [Authorize(Policy = "CanCreateBranch")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateBranchDto createNoteDto)
    {
        var command = _mapper.Map<CreateBranchCommand>(createNoteDto);
        var branchId = await Mediator.Send(command);
        return Ok(branchId);
    }

    /// <summary>
    /// Update Branch by Id
    /// </summary>
    /// <param name="updateBranchDto"></param>
    /// <returns></returns>
    [HttpPut]
    //[Authorize]
    [Authorize(Policy = "CanUpdateBranch")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Update([FromBody] UpdateBranchDto updateBranchDto)
    {
        var command = _mapper.Map<UpdateBranchCommand>(updateBranchDto);
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
     #if DEBUG
    [ApiExplorerSettings(IgnoreApi = true)]
    #else
    [ApiExplorerSettings(IgnoreApi = true)]
    #endif
    [HttpDelete("{Id}")]
    //[Authorize]
    [Authorize(Policy = "CanDeleteBranch")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Delete(int Id)
    {
        var query = new DeleteBranchCommand
        {
            Id = Id
        };
        await Mediator.Send(query);
        return NoContent();
    }

    /// <summary>
    /// Delete list of Branches by Id
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="deleteBranchesDto">Id of the Branch</param>
    /// <returns>
    /// Returns NoContent
    /// </returns>
    /// <responce code="204">Success</responce>
    /// <responce code="401">If the user is unauthorized</responce>
    /// ("DeleteBranches")
    [HttpPost("DeleteBranches")]
    [Authorize(Policy = "CanDeleteBranches")]
    //[Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> DeleteBranches([FromBody] DeleteBranchesDto deleteBranchesDto)
    {
        var command = _mapper.Map<DeleteBranchesCommand>(deleteBranchesDto);
        await Mediator.Send(command);

        return NoContent();
    }
}