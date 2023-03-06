using AutoMapper;
using EDSystems.Application.Users.Commands.AddToRole;
using EDSystems.Application.Users.Commands.CreateUser;
using EDSystems.Application.Users.Commands.DeleteFromRole;
using EDSystems.Application.Users.Commands.DeleteUser;
using EDSystems.Application.Users.Commands.UpdatePassword;
using EDSystems.Application.Users.Commands.UpdateUser;
using EDSystems.Application.Users.Commands.UpdateUserRole;
using EDSystems.Application.Users.Queries.GetUserDetails;
using EDSystems.Application.Users.Queries.GetUserList;
using EDSystems.Application.Users.Queries.GetUserListWithPagination;
using EDSystems.WebApi.Models.UserManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EDSystems.WebApi.Controllers
{
    /// <summary>
    /// User Manager
    /// </summary>
    [Authorize(Roles = "Administrator")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UserManagerController : BaseController
    {
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mapper"></param>
        public UserManagerController(IMapper mapper) => _mapper = mapper;

        /// <summary>
        /// Get the lists of Users
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /Users
        /// </remarks>
        /// <returns>
        /// Return UserListVm
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
        public async Task<ActionResult<UserListVm>> GetAll()
        {
            var query = new GetUserListQuery
            {
                //UserId = UserId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Get the lists of Users WithPagination
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /Users
        /// </remarks>
        /// <returns>
        /// Return UserListVm
        /// </returns>
        /// <responce code="200">Success</responce>
        /// <responce code="401">If the user is unauthorized</responce>
        /// ("WithPagination")
        [HttpGet]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<UserListVmWithPagination>> GetAllWithPagination(int PageNumber, int PageSize)
        {
            var query = new GetUserListWithPaginationQuery
            {
                PageNumber = PageNumber,
                PageSize = PageSize
                //UserId = UserId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Get User by Id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /user/{1}
        /// </remarks>
        /// <param name="Id">User Id (string)</param>
        /// <returns>
        /// Return UserDetailsVm
        /// </returns>
        /// <responce code="200">Success</responce>
        /// <responce code="401">If the user is unauthorized</responce>
        [HttpGet("{Id}")]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<UserDetailsVm>> Get(string Id)
        {
            var query = new GetUserDetailsQuery
            {
                Id = Id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Create User
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns>
        /// Return UserId
        /// </returns>
        /// <responce code="200">Success</responce>
        /// <responce code="401">If the user is unauthorized</responce>
        [HttpPost]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateUserDto createUserDto)
        {
            var command = _mapper.Map<CreateUserCommand>(createUserDto);
            var userId = await Mediator.Send(command);
            return Ok(userId);
        }

        /// <summary>
        /// Update User by Id
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="updateUserDto">UpdateUserDto object</param>
        /// <returns>
        /// Returns NoContent
        /// </returns>
        /// <responce code="204">Success</responce>
        /// <responce code="401">If the user is unauthorized</responce>
        [HttpPut]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Update([FromBody] UpdateUserDto updateUserDto)
        {
            var command = _mapper.Map<UpdateUserCommand>(updateUserDto);
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Update User Role
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="updateUserRoleDto">UpdateUserRoleDto object</param>
        /// <returns>
        /// Returns NoContent
        /// </returns>
        /// <responce code="204">Success</responce>
        /// <responce code="401">If the user is unauthorized</responce>
        [HttpPost("UpdateUserRole")]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> UpdateUserRole([FromBody] UpdateUserRoleDto updateUserRoleDto)
        {
            var command = _mapper.Map<UpdateUserRoleCommand>(updateUserRoleDto);
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Add To Role
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="addToRoleDto">AddToRoleDto object</param>
        /// <returns>
        /// Returns NoContent
        /// </returns>
        /// <responce code="204">Success</responce>
        /// <responce code="401">If the user is unauthorized</responce>
        [HttpPost("AddToRole")]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> AddToRole([FromBody] AddToRoleDto addToRoleDto)
        {
            var command = _mapper.Map<AddToRoleCommand>(addToRoleDto);
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Delete From Role
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="deleteFromRoleDto">DeleteFromRoleDto object</param>
        /// <returns>
        /// Returns NoContent
        /// </returns>
        /// <responce code="204">Success</responce>
        /// <responce code="401">If the user is unauthorized</responce>
        [HttpPost("DeleteFromRole")]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> DeleteFromRole([FromBody] DeleteFromRoleDto deleteFromRoleDto)
        {
            var command = _mapper.Map<DeleteFromRoleCommand>(deleteFromRoleDto);
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Update Password
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="updatePasswordDto">UpdatePasswordDto object</param>
        /// <returns>
        /// Returns NoContent
        /// </returns>
        /// <responce code="204">Success</responce>
        /// <responce code="401">If the user is unauthorized</responce>
        [HttpPost("UpdatePassword")]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> UpdatePassword([FromBody] UpdatePasswordDto updatePasswordDto)
        {
            var command = _mapper.Map<UpdatePasswordCommand>(updatePasswordDto);
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Delete the User by id
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="Id">Id of the User</param>
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
            var query = new DeleteUserCommand
            {
                Id = Id
            };
            await Mediator.Send(query);
            return NoContent();
        }
    }
}