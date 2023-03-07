using AutoMapper;
using EDSystems.Application.EDSystems.Commands.ParcelJobs.CreateParcelJob;
using EDSystems.Application.EDSystems.Commands.ParcelJobs.DeleteParcelJob;
using EDSystems.Application.EDSystems.Commands.ParcelJobs.UpdateParcelJob;
using EDSystems.Application.EDSystems.Queries.ParcelJobs.GetParcelJobDetails;
using EDSystems.Application.EDSystems.Queries.ParcelJobs.GetParcelJobList;
using EDSystems.Application.EDSystems.Queries.ParcelJobs.GetParcelJobListWithPagination;
using EDSystems.WebApi.Models.Branches;
using EDSystems.WebApi.Models.ParcelJob;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EDSystems.WebApi.Controllers;

/// <summary>
/// Branches
/// </summary>

[Authorize(Roles = "Administrator")]
//[Authorize(Policy = "OnlyForLondon")]
[Produces("application/json")]
[Route("api/[controller]")]
public class ParcelJobController : BaseController
{
    private readonly IMapper _mapper;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="mapper"></param>
    public ParcelJobController(IMapper mapper) => _mapper = mapper;

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
#if DEBUG
    [ApiExplorerSettings(IgnoreApi = true)]
#else
        [ApiExplorerSettings(IgnoreApi = true)]
#endif
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<ParcelJobListVm>> GetAll()
    {
        var query = new GetParcelJobListQuery
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
    /// ("WithPagination")
    [HttpGet("WithPagination")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<ParcelJobListVmWithPagination>> GetAllWithPagination(int PageNumber, int PageSize)
    {
        var query = new GetParcelJobListWithPaginationQuery
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
    public async Task<ActionResult<ParcelJobDetailsVm>> Get(int Id)
    {
        var query = new GetParcelJobDetailsQuery
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
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateBranchDto createNoteDto)
    {
        var command = _mapper.Map<CreateParcelJobCommand>(createNoteDto);
        var branchId = await Mediator.Send(command);
        return Ok(branchId);
    }

    /// <summary>
    /// Update Branch by Id
    /// </summary>
    /// <param name="updateParcelJobDto"></param>
    /// <returns></returns>
    [HttpPut]
    //[Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Update([FromBody] UpdateParcelJobDto updateParcelJobDto)
    {
        var command = _mapper.Map<UpdateParcelJobCommand>(updateParcelJobDto);
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
        var query = new DeleteParcelJobCommand
        {
            Id = Id
        };
        await Mediator.Send(query);
        return NoContent();
    }
}