using AutoMapper;
using EDSystems.Application.Roles.Commands.CreateRole;
using EDSystems.Application.Roles.Commands.DeleteRole;
using EDSystems.Application.Roles.Commands.UpdateRole;
using EDSystems.Application.Roles.Queries.GetRoleDetails;
using EDSystems.Application.Roles.Queries.GetRoleList;
using EDSystems.Application.Roles.Queries.GetRoleListWithPagination;
using EDSystems.WebApi.Models.RoleManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EDSystems.WebApi.Controllers
{
    /// <summary>
    /// Branches
    /// </summary>

    [Authorize(Roles = "Administrator")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class RoleManagerController : BaseController
    {
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mapper"></param>
        public RoleManagerController(IMapper mapper) => _mapper = mapper;

        /// <summary>
        /// Get the list of Roles
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns>
        /// Return RoleListVm
        /// </returns>
        /// <responce code="200">Success</responce>
        /// <responce code="401">If the user is unauthorized</responce>
#if DEBUG
        [ApiExplorerSettings(IgnoreApi = true)]
#else
        [ApiExplorerSettings(IgnoreApi = true)]
#endif
        [HttpGet]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<RoleListVm>> GetAll()
        {
            var query = new GetRoleListQuery
            {
                //UserId = UserId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Get the list of Roles with pagination list
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns>
        /// Return RoleListVm
        /// </returns>
        /// <responce code="200">Success</responce>
        /// <responce code="401">If the user is unauthorized</responce>
        ///("WithPagination")
        [HttpGet]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<RoleListVmWithPagination>> GetAllWithPagination(int PageNumber, int PageSize)
        {
            var query = new GetRoleListWithPaginationQuery
            {
                PageNumber = PageNumber,
                PageSize = PageSize
                //UserId = UserId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Get Role by Id
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="Id">Role Id (int)</param>
        /// <returns>
        /// Return RoleDetailsVm
        /// </returns>
        /// <responce code="200">Success</responce>
        /// <responce code="401">If the user is unauthorized</responce>
        [HttpGet("{Id}")]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<RoleDetailsVm>> Get(string Id)
        {
            var query = new GetRoleDetailsQuery
            {
                Id = Id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Create Role
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns>
        /// Return Id (int)
        /// </returns>
        /// <param name="createRoleDto">CreateRoleDto object</param>
        /// <responce code="200">Success</responce>
        /// <responce code="401">If the user is unauthorized</responce>
        [HttpPost]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateRoleDto createRoleDto)
        {
            var command = _mapper.Map<CreateRoleCommand>(createRoleDto);
            var userId = await Mediator.Send(command);
            return Ok(userId);
        }

        /// <summary>
        /// Update Role by Id
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="updateUserDto">UpdateRoleDto object</param>
        /// <returns>
        /// Returns NoContent
        /// </returns>
        /// <responce code="204">Success</responce>
        /// <responce code="401">If the user is unauthorized</responce>
        [HttpPut]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Update([FromBody] UpdateRoleDto updateUserDto)
        {
            var command = _mapper.Map<UpdateRoleCommand>(updateUserDto);
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Delete the Role by Id
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="Id">Id of the Role</param>
        /// <returns>
        /// Returns NoContent
        /// </returns>
        /// <responce code="204">Success</responce>
        /// <responce code="401">If the user is unauthorized</responce>
        [HttpDelete("{Id}")]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Delete(string Id)
        {
            var query = new DeleteRoleCommand
            {
                Id = Id
            };
            await Mediator.Send(query);
            return NoContent();
        }
    }
}