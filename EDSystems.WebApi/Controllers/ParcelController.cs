using AutoMapper;
using EDSystems.Application.EDSystems.Commands.Parcels.AddParcelImage;
using EDSystems.Application.EDSystems.Commands.Parcels.AddParcelImages;
using EDSystems.Application.EDSystems.Commands.Parcels.AddParcelSound;
using EDSystems.Application.EDSystems.Commands.Parcels.AddParcelSounds;
using EDSystems.Application.EDSystems.Commands.Parcels.AddParcelStatus;
using EDSystems.Application.EDSystems.Commands.Parcels.CreateParcel;
using EDSystems.Application.EDSystems.Commands.Parcels.DeleteImageFromParcel;
using EDSystems.Application.EDSystems.Commands.Parcels.DeleteParcel;
using EDSystems.Application.EDSystems.Commands.Parcels.DeleteParcelImages;
using EDSystems.Application.EDSystems.Commands.Parcels.DeleteParcels;
using EDSystems.Application.EDSystems.Commands.Parcels.DeleteParcelSound;
using EDSystems.Application.EDSystems.Commands.Parcels.DeleteParcelSounds;
using EDSystems.Application.EDSystems.Commands.Parcels.DeleteParcelStatus;
using EDSystems.Application.EDSystems.Commands.Parcels.UpdateParcel;
using EDSystems.Application.EDSystems.Commands.Parcels.UpdateParcelImage;
using EDSystems.Application.EDSystems.Commands.Parcels.UpdateParcelImages;
using EDSystems.Application.EDSystems.Commands.Parcels.UpdateParcelSound;
using EDSystems.Application.EDSystems.Commands.Parcels.UpdateParcelSounds;
using EDSystems.Application.EDSystems.Commands.Parcels.UpdateParcelsStatusByCode;
using EDSystems.Application.EDSystems.Commands.Parcels.UpdateParcelsStatusById;
using EDSystems.Application.EDSystems.Commands.Parcels.UpdateParcelStatusById;
using EDSystems.Application.EDSystems.Queries.Parcels.GetParcelDetails;
using EDSystems.Application.EDSystems.Queries.Parcels.GetParcelList;
using EDSystems.Application.EDSystems.Queries.Parcels.GetParcelListWithPagination;
using EDSystems.WebApi.Models.Parcel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace EDSystems.WebApi.Controllers
{
    /// <summary>
    ///
    /// </summary>
    [Authorize(Roles = "Administrator")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ParcelController : BaseController
    {
        private readonly IMapper _mapper;

        /// <summary>
        /// Contructor
        /// </summary>
        /// <param name="mapper"></param>
        public ParcelController(IMapper mapper) => _mapper = mapper;

        /// <summary>
        /// Add Parcel Image ONE
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns>
        /// Return NoContent
        /// </returns>
        /// <param name="addParcelImageDto">AddParcelImageDto object</param>
        /// <responce code="200">Success</responce>
        /// <responce code="401">If the user is unauthorized</responce>
        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost("AddParcelImage")]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> AddParcelImage([FromBody] AddParcelImageDto addParcelImageDto)
        {
            var command = _mapper.Map<AddParcelImageCommand>(addParcelImageDto);
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Add Parcel Images Many
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns>
        /// Return NoContent
        /// </returns>
        /// <param name="addParcelImagesDto">AddParcelImageDto object</param>
        /// <responce code="200">Success</responce>
        /// <responce code="401">If the user is unauthorized</responce>
        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost("AddParcelImages")]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> AddParcelImages([FromBody] AddParcelImagesDto addParcelImagesDto)
        {
            var command = _mapper.Map<AddParcelImagesCommand>(addParcelImagesDto);
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Add Parcel Sound ONE
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns>
        /// Return NoContent
        /// </returns>
        /// <param name="addParcelSoundDto">AddParcelSoundDto object</param>
        /// <responce code="200">Success</responce>
        /// <responce code="401">If the user is unauthorized</responce>
        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost("AddParcelSound")]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> AddParcelSound([FromBody] AddParcelSoundDto addParcelSoundDto)
        {
            var command = _mapper.Map<AddParcelSoundCommand>(addParcelSoundDto);
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Add Parcel Sounds Many
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns>
        /// Return NoContent
        /// </returns>
        /// <param name="addParcelSoundsDto">AddParcelSoundsDto object</param>
        /// <responce code="200">Success</responce>
        /// <responce code="401">If the user is unauthorized</responce>
        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost("AddParcelSounds")]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> AddParcelSounds([FromBody] AddParcelSoundsDto addParcelSoundsDto)
        {
            var command = _mapper.Map<AddParcelSoundsCommand>(addParcelSoundsDto);
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Add Parcel Status
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns>
        /// Return NoContent
        /// </returns>
        /// <param name="addParcelStatus">AddParcelStatusDto object</param>
        /// <responce code="200">Success</responce>
        /// <responce code="401">If the user is unauthorized</responce>
        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost("AddParcelStatus")]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> AddParcelStatus([FromBody] AddParcelStatusDto addParcelStatus)
        {
            var command = _mapper.Map<AddParcelStatusCommand>(addParcelStatus);
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Create Parcel
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns>
        /// Return Id (int)
        /// </returns>
        /// <param name="createParcelDto">CreateParcelDto object</param>
        /// <responce code="200">Success</responce>
        /// <responce code="401">If the user is unauthorized</responce>
        [HttpPost]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateParcelDto createParcelDto)
        {
            var command = _mapper.Map<CreateParcelCommand>(createParcelDto);
            var branchId = await Mediator.Send(command);
            return Ok(branchId);
        }

        /// <summary>
        /// Delete Parcel by Id
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="Id">Id of the note</param>
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
            var query = new DeleteParcelCommand
            {
                Id = Id
            };
            await Mediator.Send(query);
            return NoContent();
        }

        /// <summary>
        /// Delete one of parcel image
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns>
        /// Return NoContent
        /// </returns>
        /// <param name="deleteParcelImageDto">DeleteParcelImageDto object</param>
        /// <responce code="200">Success</responce>
        /// <responce code="401">If the user is unauthorized</responce>
        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost("DeleteParcelImage")]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> DeleteParcelImage([FromBody] DeleteParcelImageDto deleteParcelImageDto)
        {
            var command = _mapper.Map<DeleteParcelImageCommand>(deleteParcelImageDto);
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Delete list of Parcel Images by Id
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns>
        /// Returns NoContent
        /// </returns>
        /// <responce code="204">Success</responce>
        /// <responce code="401">If the user is unauthorized</responce>
        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost("DeleteParcelImages")]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> DeleteParcelImages([FromBody] DeleteParcelImagesDto deleteParcelImagesDto)
        {
            var command = _mapper.Map<DeleteParcelImagesCommand>(deleteParcelImagesDto);
            await Mediator.Send(command);

            return NoContent();
        }

        /// <summary>
        /// Delete list of Parcels by Id
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="deleteParcelsDto">Id of the Branch</param>
        /// <returns>
        /// Returns NoContent
        /// </returns>
        /// <responce code="204">Success</responce>
        /// <responce code="401">If the user is unauthorized</responce>
        [HttpPost("DeleteParcels")]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> DeleteParcels([FromBody] DeleteParcelsDto deleteParcelsDto)
        {
            var command = _mapper.Map<DeleteParcelsCommand>(deleteParcelsDto);
            await Mediator.Send(command);

            return NoContent();
        }

        /// <summary>
        /// Delete Parcel Sound ONE
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns>
        /// Return NoContent
        /// </returns>
        /// <param name="deleteParcelSoundDto">DeleteParcelSoundDto object</param>
        /// <responce code="200">Success</responce>
        /// <responce code="401">If the user is unauthorized</responce>
        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost("DeleteParcelSound")]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> DeleteParcelSound([FromBody] DeleteParcelSoundDto deleteParcelSoundDto)
        {
            var command = _mapper.Map<DeleteParcelSoundCommand>(deleteParcelSoundDto);
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Delete list of Parcel Sounds by Id
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns>
        /// Returns NoContent
        /// </returns>
        /// <responce code="204">Success</responce>
        /// <responce code="401">If the user is unauthorized</responce>
        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost("DeleteParcelSounds")]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> DeleteParcelSounds([FromBody] DeleteParcelSoundsDto deleteParcelSoundsDto)
        {
            var command = _mapper.Map<DeleteParcelSoundsCommand>(deleteParcelSoundsDto);
            await Mediator.Send(command);

            return NoContent();
        }

        /// <summary>
        /// Delete Parcel Status
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns>
        /// Return NoContent
        /// </returns>
        /// <param name="deleteParcelStatusDto">DeleteParcelStatusDto object</param>
        /// <responce code="200">Success</responce>
        /// <responce code="401">If the user is unauthorized</responce>
        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost("DeleteParcelStatus")]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> DeleteParcelStatus([FromBody] DeleteParcelStatusDto deleteParcelStatusDto)
        {
            var command = _mapper.Map<DeleteParcelStatusCommand>(deleteParcelStatusDto);
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Get Parcel by Id
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="Id">Parcel Id (guid)</param>
        /// <returns>
        /// Return NoteDetailsVm
        /// </returns>
        /// <responce code="200">Success</responce>
        /// <responce code="401">If the user is unauthorized</responce>
        [HttpGet("{Id}")]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<ParcelDetailsVm>> Get(int Id)
        {
            var query = new GetParcelDetailsQuery
            {
                Id = Id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Get the list of Parcels
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns>
        /// Return ParcelListVm
        /// </returns>
        /// <responce code="200">Success</responce>
        /// <responce code="401">If the user is unauthorized</responce>
        [HttpGet]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<ParcelListVm>> GetAll()
        {
            var query = new GetParcelListQuery
            {
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Get the list of parcels with pagination
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns>
        /// Return ParcelListVm
        /// </returns>
        /// <responce code="200">Success</responce>
        /// <responce code="401">If the user is unauthorized</responce>
        [HttpGet("WithPagination")]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<ParcelListVmWithPagination>> GetAllWithPagination()
        {
            var query = new GetParcelListWithPaginationQuery
            {
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Update Parcel by Id
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="updateParcelDto">UpdateParcelDto object</param>
        /// <returns>
        /// Returns NoContent
        /// </returns>
        /// <responce code="204">Success</responce>
        /// <responce code="401">If the user is unauthorized</responce>
        [HttpPut]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Update([FromBody] UpdateParcelDto updateParcelDto)
        {
            var command = _mapper.Map<UpdateParcelCommand>(updateParcelDto);
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Update Parcel Image ONE
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns>
        /// Return NoContent
        /// </returns>
        /// <param name="updateParcelImageDto">UpdateParcelImageDto object</param>
        /// <responce code="200">Success</responce>
        /// <responce code="401">If the user is unauthorized</responce>
        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost("UpdateParcelImage")]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> UpdateParcelImage([FromBody] UpdateParcelImageDto updateParcelImageDto)
        {
            var command = _mapper.Map<UpdateParcelImageCommand>(updateParcelImageDto);
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Update Parcel Images Many
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns>
        /// Return NoContent
        /// </returns>
        /// <param name="updateParcelImagesDto">UpdateParcelImageDto object</param>
        /// <responce code="200">Success</responce>
        /// <responce code="401">If the user is unauthorized</responce>
        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost("UpdateParcelImages")]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> UpdateParcelImages([FromBody] UpdateParcelImagesDto updateParcelImagesDto)
        {
            var command = _mapper.Map<UpdateParcelImagesCommand>(updateParcelImagesDto);
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Update Parcel Sound ONE
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns>
        /// Return NoContent
        /// </returns>
        /// <param name="updateParcelSoundDto">UpdateParcelSoundDto object</param>
        /// <responce code="200">Success</responce>
        /// <responce code="401">If the user is unauthorized</responce>
        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost("UpdateParcelSound")]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> UpdateParcelSound([FromBody] UpdateParcelSoundDto updateParcelSoundDto)
        {
            var command = _mapper.Map<UpdateParcelSoundCommand>(updateParcelSoundDto);
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Update Parcel Sounds MANY
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns>
        /// Return NoContent
        /// </returns>
        /// <param name="updateParcelSoundsDto">UpdateParcelSoundsDto object</param>
        /// <responce code="200">Success</responce>
        /// <responce code="401">If the user is unauthorized</responce>
        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost("UpdateParcelSounds")]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> UpdateParcelSounds([FromBody] UpdateParcelSoundsDto updateParcelSoundsDto)
        {
            var command = _mapper.Map<UpdateParcelSoundsCommand>(updateParcelSoundsDto);
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Update Parcels Status By Code
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns>
        /// Return NoContent
        /// </returns>
        /// <param name="updateParcelsStatusByCodeDto">UpdateParcelsStatusByCodeDto object</param>
        /// <responce code="200">Success</responce>
        /// <responce code="401">If the user is unauthorized</responce>
        [HttpPost("UpdateParcelsStatusByCode")]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> UpdateParcelsStatusByCode([FromBody] UpdateParcelsStatusByCodeDto updateParcelsStatusByCodeDto)
        {
            var command = _mapper.Map<UpdateParcelsStatusByCodeCommand>(updateParcelsStatusByCodeDto);
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Update Parcels Status By Id
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns>
        /// Return NoContent
        /// </returns>
        /// <param name="updateParcelsStatusByIdDto">UpdateParcelsStatusByIdDto object</param>
        /// <responce code="200">Success</responce>
        /// <responce code="401">If the user is unauthorized</responce>
        [HttpPost("UpdateParcelsStatusById")]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> UpdateParcelsStatusById([FromBody] UpdateParcelsStatusByIdDto updateParcelsStatusByIdDto)
        {
            var command = _mapper.Map<UpdateParcelsStatusByIdCommand>(updateParcelsStatusByIdDto);
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Update Parcel Status By Id
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns>
        /// Return NoContent
        /// </returns>
        /// <param name="updateParcelStatusByIdDto">UpdateParcelStatusByIdDto object</param>
        /// <responce code="200">Success</responce>
        /// <responce code="401">If the user is unauthorized</responce>
        [HttpPost("UpdateParcelStatusById")]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> UpdateParcelStatusById([FromBody] UpdateParcelStatusByIdDto updateParcelStatusByIdDto)
        {
            var command = _mapper.Map<UpdateParcelStatusByIdCommand>(updateParcelStatusByIdDto);
            await Mediator.Send(command);
            return NoContent();
        }
    }
}