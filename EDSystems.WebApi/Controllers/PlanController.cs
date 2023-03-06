using AutoMapper;
using EDSystems.Application.EDSystems.Commands.Plans.CreatePlan;
using EDSystems.Application.EDSystems.Commands.Plans.DeletePlan;
using EDSystems.Application.EDSystems.Commands.Plans.DeletePlans;
using EDSystems.Application.EDSystems.Commands.Plans.UpdatePlan;
using EDSystems.Application.EDSystems.Queries.Plans.GetPlanDetails;
using EDSystems.Application.EDSystems.Queries.Plans.GetPlanList;
using EDSystems.Application.EDSystems.Queries.Plans.GetPlanListWithPagination;
using EDSystems.WebApi.Models.Plan;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EDSystems.WebApi.Controllers
{
    /// <summary>
    ///
    /// </summary>
    //[Authorize(Roles = "Administrator")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class PlanController : BaseController
    {
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mapper"></param>
        public PlanController(IMapper mapper) => _mapper = mapper;

        /// <summary>
        /// Get the list of Plans
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns>
        /// Return PlanListVm
        /// </returns>
        /// <responce code="200">Success</responce>
        /// <responce code="401">If the user is unauthorized</responce>
        [HttpGet]
        [Authorize(Policy = "CanGetAllPlans")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<PlanListVm>> GetAll()
        {
            var query = new GetPlanListQuery
            {
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Get the list of Plans
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns>
        /// Return PlanListVm
        /// </returns>
        /// <responce code="200">Success</responce>
        /// <responce code="401">If the user is unauthorized</responce>
        [HttpGet("WithPagination")]
        [Authorize(Policy = "CanGetAllPlansWithPagination")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<PlanListVmWithPagination>> GetAllWithPagination(int PageNumber, int PageSize)
        {
            var query = new GetPlanListWithPaginationQuery
            {
                PageNumber = PageNumber,
                PageSize = PageSize
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Get Plan by Id
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="Id">Plan Id (guid)</param>
        /// <returns>
        /// Return PlanDetailsVm
        /// </returns>
        /// <responce code="200">Success</responce>
        /// <responce code="401">If the user is unauthorized</responce>
        [HttpGet("{Id}")]
        [Authorize(Policy = "CanGetPlanDetails")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<PlanDetailsVm>> Get(int Id)
        {
            var query = new GetPlanDetailsQuery
            {
                Id = Id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Create Plan
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns>
        /// Return Id (int)
        /// </returns>
        /// <param name="createPlanDto">CreatePlanDto object</param>
        /// <responce code="200">Success</responce>
        /// <responce code="401">If the user is unauthorized</responce>
        [HttpPost]
        [Authorize(Policy = "CanCreatePlan")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreatePlanDto createPlanDto)
        {
            var command = _mapper.Map<CreatePlanCommand>(createPlanDto);
            var branchId = await Mediator.Send(command);
            return Ok(branchId);
        }

        /// <summary>
        /// Update Plan by Id
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="updatePlanDto">UpdatePlanDto object</param>
        /// <returns>
        /// Returns NoContent
        /// </returns>
        /// <responce code="204">Success</responce>
        /// <responce code="401">If the user is unauthorized</responce>
        [HttpPut]
        [Authorize(Policy = "CanUpdatePlan")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Update([FromBody] UpdatePlanDto updatePlanDto)
        {
            var command = _mapper.Map<UpdatePlanCommand>(updatePlanDto);
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Delete the Plan by Id
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="Id">Id of the Plan</param>
        /// <returns>
        /// Returns NoContent
        /// </returns>
        /// <responce code="204">Success</responce>
        /// <responce code="401">If the user is unauthorized</responce>
        [HttpDelete("{Id}")]
        [Authorize(Policy = "CanDeletePlan")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Delete(int Id)
        {
            var query = new DeletePlanCommand
            {
                Id = Id
            };
            await Mediator.Send(query);
            return NoContent();
        }

        /// <summary>
        /// Delete list of Plans by Id
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="deletePlansDto">Id of the Plans</param>
        /// <returns>
        /// Returns NoContent
        /// </returns>
        /// <responce code="204">Success</responce>
        /// <responce code="401">If the user is unauthorized</responce>
        [HttpPost("DeletePlans")]
        [Authorize(Policy = "CanDeletePlans")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> DeletePlans([FromBody] DeletePlansDto deletePlansDto)
        {
            var command = _mapper.Map<DeletePlansCommand>(deletePlansDto);
            await Mediator.Send(command);

            return NoContent();
        }
    }
}