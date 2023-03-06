﻿using AutoMapper;
using EDSystems.Application.EDSystems.Commands.Statuses.CreateStatus;
using EDSystems.Application.EDSystems.Commands.Statuses.DeleteStatus;
using EDSystems.Application.EDSystems.Commands.Statuses.DeleteStatuses;
using EDSystems.Application.EDSystems.Commands.Statuses.UpdateStatus;
using EDSystems.Application.EDSystems.Queries.Statuses.GetStatusDetails;
using EDSystems.Application.EDSystems.Queries.Statuses.GetStatusList;
using EDSystems.Application.EDSystems.Queries.Statuses.GetStatusListWithPagination;
using EDSystems.WebApi.Models.Status;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EDSystems.WebApi.Controllers
{
    /// <summary>
    ///
    /// </summary>
    [Authorize(Roles = "Administrator")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class StatusController : BaseController
    {
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mapper"></param>
        public StatusController(IMapper mapper) => _mapper = mapper;

        /// <summary>
        /// Get the lists of Statuses
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns>
        /// Return StatusListVm
        /// </returns>
        /// <responce code="200">Success</responce>
        /// <responce code="401">If the user is unauthorized</responce>
#if DEBUG
        [ApiExplorerSettings(IgnoreApi = true)]
#else
        [ApiExplorerSettings(IgnoreApi = true)]
#endif
        [HttpGet]
        [Authorize(Policy = "CanGetAllStatuses")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<StatusListVm>> GetAll()
        {
            var query = new GetStatusListQuery
            {
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Get the lists of Statuses with pagination
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns>
        /// Return StatusListVm
        /// </returns>
        /// <responce code="200">Success</responce>
        /// <responce code="401">If the user is unauthorized</responce>
        ///("WithPagination")
        [HttpGet]
        [Authorize(Policy = "CanGetAllStatusesWithPagination")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<StatusListVmWithPagination>> GetAllWithPagination(int PageSize, int PageNumber)
        {
            var query = new GetStatusListWithPaginationQuery
            {
                PageSize = PageSize,
                PageNumber = PageNumber
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Get Status by Id
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="Id">Status Id (int)</param>
        /// <returns>
        /// Return StatusDetailsVm
        /// </returns>
        /// <responce code="200">Success</responce>
        /// <responce code="401">If the user is unauthorized</responce>
        [HttpGet("{Id}")]
        [Authorize(Policy = "CanGetStatusDetails")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<StatusDetailsVm>> Get(int Id)
        {
            var query = new GetStatusDetailsQuery
            {
                Id = Id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Create Status
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns>
        /// Return Id (int)
        /// </returns>
        /// <param name="createStatusDto">CreateStatusDto object</param>
        /// <responce code="200">Success</responce>
        /// <responce code="401">If the user is unauthorized</responce>
        [HttpPost]
        [Authorize(Policy = "CanCreateStatus")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateStatusDto createStatusDto)
        {
            var command = _mapper.Map<CreateStatusCommand>(createStatusDto);
            var statusId = await Mediator.Send(command);
            return Ok(statusId);
        }

        /// <summary>
        /// Update the Status
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="updateStatusDto">UpdateStatusDto object</param>
        /// <returns>
        /// Returns NoContent
        /// </returns>
        /// <responce code="204">Success</responce>
        /// <responce code="401">If the user is unauthorized</responce>
        [HttpPut]
        [Authorize(Policy = "CanUpdateStatus")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Update([FromBody] UpdateStatusDto updateStatusDto)
        {
            var command = _mapper.Map<UpdateStatusCommand>(updateStatusDto);
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Delete the Status by Id
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="Id">Id of the Status</param>
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
        [Authorize(Policy = "CanDeleteStatus")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Delete(int Id)
        {
            var query = new DeleteStatusCommand
            {
                Id = Id
            };
            await Mediator.Send(query);
            return NoContent();
        }

        /// <summary>
        /// Delete list of Statuses by Id
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="deleteStatusesDto">Id of the Status</param>
        /// <returns>
        /// Returns NoContent
        /// </returns>
        /// <responce code="204">Success</responce>
        /// <responce code="401">If the user is unauthorized</responce>
        [HttpPost("DeleteStatuses")]
        [Authorize(Policy = "CanDeleteStatuses")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> DeleteStatuses([FromBody] DeleteStatusesDto deleteStatusesDto)
        {
            var command = _mapper.Map<DeleteStatusesCommand>(deleteStatusesDto);
            await Mediator.Send(command);

            return NoContent();
        }
    }
}